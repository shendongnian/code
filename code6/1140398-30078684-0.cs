                    DateTime helpDate;
                    Decimal helpNumber = 0, helpNumber2, difference;
                    DataTable dthelp = new DataTable();
                    dthelp.Columns.Add("Date");
                    dthelp.Columns.Add("Volume" + CountPlusOne);
                    dthelp.PrimaryKey = new DataColumn[] { dthelp.Columns[0] };
                    int i = 0;
                    foreach (DataRow row in dtlist[count].Rows)
                    {
                        if (i > 0)
                        {
                            helpNumber2 = Decimal.Parse(row["Volume" + CountPlusOne].ToString().Replace('.', ','));
                            difference = (helpNumber - helpNumber2) / 4;
                            helpDate = DateTime.Parse(row["Date"].ToString());
                            dr = dthelp.NewRow();
                            dr["Date"] = helpDate.Subtract(TimeSpan.FromMinutes(45));
                            dr["Volume" + CountPlusOne] = (helpNumber - difference).ToString().Replace(',', '.');                            
                            dthelp.Rows.Add(dr);
                            
                            dr = dthelp.NewRow();
                            dr["Date"] = helpDate.Subtract(TimeSpan.FromMinutes(30));
                            dr["Volume" + CountPlusOne] = (helpNumber - difference * 2).ToString().Replace(',', '.');                            
                            dthelp.Rows.Add(dr);
                            
                            dr = dthelp.NewRow();
                            dr["Date"] = helpDate.Subtract(TimeSpan.FromMinutes(15));
                            dr["Volume" + CountPlusOne] = (helpNumber - difference * 3).ToString().Replace(',', '.');
                            dthelp.Rows.Add(dr);
                        }
                        i++;
                        helpNumber = Decimal.Parse(row["Volume" + CountPlusOne].ToString().Replace('.', ','));
                    }
