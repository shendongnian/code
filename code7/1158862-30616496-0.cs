    string csvPath = System.Web.Hosting.HostingEnvironment.MapPath("pathToCSV.csv");
    StreamWriter sw = new StreamWriter(csvPath, false);
    if (dtDataTablesList.Rows.Count > 0)
                            {
                                //First we will write the headers.
                                int iColCount = dtDataTablesList.Columns.Count;
    
                                for (int i = 0; i < iColCount; i++)
                                {
                                    sw.Write(dtDataTablesList.Columns[i]);
                                    if (i < iColCount - 1)
                                    {
                                        sw.Write(",");
                                    }
                                }
                                sw.Write(sw.NewLine);
    
                                // Now write all the rows.
                                foreach (DataRow dr in dtDataTablesList.Rows)
                                {
                                    for (int i = 0; i < iColCount; i++)
                                    {
                                        if (!Convert.IsDBNull(dr[i]))
                                        {
                                            sw.Write(dr[i].ToString());
                                        }
                                        if (i < iColCount - 1)
                                        {
                                            sw.Write(",");
                                        }
                                    }
                                    sw.Write(sw.NewLine);
                                }
                            }
