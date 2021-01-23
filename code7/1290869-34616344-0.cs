                    // are there any extras attached to the work order
                    using (var cmdExtras = new OleDbCommand(sql, conn)) 
                    using (var extrasReader = cmdExtras.ExecuteReader()) {
                        ExtraModel extra;
                        List<ExtraModel> extList = new List<ExtraModel>();
                        while (extrasReader.Read())
                        {
                            extra = new ExtraModel();
                            extra.setOrderID((int)extrasReader.GetValue(1));
                            extra.setDescription(extrasReader.GetString(2));
                            extra.setPrice((double)extrasReader.GetDecimal(3));
                            extList.Add(extra);
                        }
                        if (extList.Any()) wom.setExtras(extList);
                    }
