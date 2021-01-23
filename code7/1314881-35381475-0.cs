        public override void Calculate()
        {
            int outbegldx = 0;
            int outnbelement = 0;
            int marketID = 0;
            TicTacTec.TA.Library.Core.RetCode retCode;
            //Queue<OHLC> input = new Queue<OHLC>();
            Queue<double> inputHigh = new Queue<double>();
            Queue<double> inputLow = new Queue<double>();
            Queue<double> inputClose = new Queue<double>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB_CONNECTION_STRING))
            {
                using (SqlCommand cmd = new SqlCommand("[Data].[proc_GetHistoricalData]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StartIndex", SqlDbType.Int);
                    cmd.Parameters.Add("@EndIndex", SqlDbType.Int);
                    cmd.Parameters.Add("@Weekly", SqlDbType.Bit);
                    cmd.Parameters["@StartIndex"].Value = this.startIndex;
                    cmd.Parameters["@EndIndex"].Value = this.endIndex;
                    cmd.Parameters["@Weekly"].Value = (int)this.TimeFrame;
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr.GetInt64(0));
                            if (marketID != rdr.GetInt32(2))
                            {
                                marketID = rdr.GetInt32(2);
                                inputHigh.Clear();
                                inputLow.Clear();
                                inputClose.Clear();
                            }
                            //input.Enqueue(new OHLC(rdr.GetDecimal(4), rdr.GetDecimal(5), rdr.GetDecimal(6), rdr.GetDecimal(7)));
                            inputHigh.Enqueue(Convert.ToDouble(rdr.GetDecimal(5)));
                            inputLow.Enqueue(Convert.ToDouble(rdr.GetDecimal(6)));
                            inputClose.Enqueue(Convert.ToDouble(rdr.GetDecimal(7)));
                            //We have enough data to calculate the ATR so do so
                            if (inputHigh.Count >= this.Period + 1)
                            {
                                double[] outreal = new double[inputHigh.Count - 1];
                                int lookBack = Core.AtrLookback(this.Period);
                                retCode = Core.Atr(0, inputHigh.Count - 1, inputHigh.ToArray(), inputLow.ToArray(), inputClose.ToArray(), lookBack, out outbegldx, out outnbelement, outreal);
                                //Calculated the ATR, now write it to the database
                                if (retCode == Core.RetCode.Success)
                                {
                                    this.Output = new AverageTrueRangeOutput(this.Period, outreal[0], outbegldx, outnbelement);
                                    //Now insert into db
                                    using (SqlCommand cmdInsert = new SqlCommand("[Data].[proc_InsertHistoricalIndicator]", conn))
                                    {
                                        cmdInsert.CommandType = CommandType.StoredProcedure;
                                        cmdInsert.Parameters.Add("@MarketID", SqlDbType.Int);
                                        cmdInsert.Parameters.Add("@IndicatorID", SqlDbType.Int);
                                        cmdInsert.Parameters.Add("@Date", SqlDbType.Date);
                                        cmdInsert.Parameters.Add("@Value", SqlDbType.Xml);
                                        cmdInsert.Parameters.Add("@Weekly", SqlDbType.Bit);
                                        cmdInsert.Parameters["@MarketID"].Value = rdr.GetInt32(2);
                                        cmdInsert.Parameters["@IndicatorID"].Value = this.Id;
                                        cmdInsert.Parameters["@Weekly"].Value = (int)this.TimeFrame;
                                        cmdInsert.Parameters["@Date"].Value = rdr.GetDateTime(3);  //IBLib.Util.GetDate(
                                        cmdInsert.Parameters["@Value"].Value = this.Output.toXML().OuterXml;
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                }
                                inputHigh.Dequeue();
                                inputLow.Dequeue();
                                inputClose.Dequeue();
                            }
                        }
                        rdr.Close();
                    }
                }
            }
        }
