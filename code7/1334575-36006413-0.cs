    try
            {
                con.Open();
                com.CommandText = "SELECT * FROM edlr_comm_rep_total a where a.dealer_id = 'wb-pos00289' and a.comm_type = 'Activation' ";
                //com.Parameters.Add("msisdn", OracleDbType.Char).Value = msisdn;
                
                var reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Dictionary<String, String> objDic = new Dictionary<string, string>();
                        string CommissionDealerId = reader[0].ToString();
                        string Month = reader[1].ToString();
                        string DealerCommissionType = reader[2].ToString();
                        string CommissionCount = reader[3].ToString();
                        string CommissionAmount = reader[4].ToString();
                        objDic["CommissionDealerId"] = CommissionDealerId;
                        objDic["Month"] = Month;
                        objDic["DealerCommissionType"] = DealerCommissionType;
                        objDic["CommissionCount"] = CommissionCount;
                        objDic["CommissionAmount"] = CommissionAmount;
                        listDic.Add(objDic);
                    }
                }
                reader.Close();
            }
