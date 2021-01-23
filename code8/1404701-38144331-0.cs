    using (MYSQLCON)
            {
                using (MySqlDataReader sdr = sqlcmd.ExecuteReader())
                using (YourWriter)
                {
                    String Header = null;
                    String Content = null;
                    for (int i = 0; i <= sdr.FieldCount - 1; i++)
                    {
                        Header = Header + sdr.GetName(i).ToString() + ",";
                    }
                    YourWriter.WriteLine(Header);
                    while (sdr.Read())
                        for (int i = 0; i <= sdr.FieldCount - 1; i++)
                        {
                            Content = Content + sdr[i].ToString() + ",";
                            if (i == sdr.FieldCount - 1)
                            {
                                YourWriter.WriteLine(Content);
                                Content = null;
                            }
                        }
                }
            }
