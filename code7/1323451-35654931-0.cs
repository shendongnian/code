                   using System.IO;
                    using (var sw = new StreamWriter(CSVpath))
                    {
                        foreach (DataRow row in sortedDT.Rows)
                        {
                            string[] fields = row.ItemArray.Select(field => field.ToString()).
                                                            ToArray();
                            sw.WriteLine(string.Join(",", fields));
        
                        }
                    }
