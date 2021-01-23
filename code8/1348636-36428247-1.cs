    using (OdbcCommand cmd = new OdbcCommand(sql, cn))
                {
                    foreach (var co in colorList)
                    {
                        cmd.Parameters.AddWithValue(co, co);
                    }
    
                        OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                        adapter.Fill(dsProducts);
    
                        if (dsProducts.Tables.Count > 0)
                        {
                            dt1 = dsProducts.Tables[0];
                        }
    
                        dtProducts = dt1;
    
                }
