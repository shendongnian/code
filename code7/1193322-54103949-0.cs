    public DataTable CSVtoDataTable(string inputpath)
       {
        
        DataTable csvdt = new DataTable();
        string Fulltext;
        if (File.Exists(inputpath))
        {
           using (StreamReader sr = new StreamReader(inputpath))
            {
                while (!sr.EndOfStream)
                {
                    Fulltext = sr.ReadToEnd().ToString();//read full content
                    string[] rows = Fulltext.Split('\n');//split file content to get the rows
                    for (int i = 0; i < rows.Count() - 1; i++)
                    {
                        var regex = new Regex("\\\"(.*?)\\\"");
                        var output = regex.Replace(rows[i], m => m.Value.Replace(",", "\\c"));//replace commas inside quotes
                        string[] rowValues = output.Split(',');//split rows with comma',' to get the column values
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < rowValues.Count(); j++)
                                {
                                    csvdt.Columns.Add(rowValues[j].Replace("\\c",","));//headers
                                }
                             
                            }
                            else
                            {
                                try
                                {
                                    DataRow dr = csvdt.NewRow();
                                    for (int k = 0; k < rowValues.Count(); k++)
                                    {
                                        if (k >= dr.Table.Columns.Count)// more columns may exist
                                        { csvdt .Columns.Add("clmn" + k);
                                            dr = csvdt .NewRow();
                                        }
                                        dr[k] = rowValues[k].Replace("\\c", ",");
                                       
                                    }
                                    csvdt.Rows.Add(dr);//add other rows
                                }
                                catch
                                {
                                    Console.WriteLine("error");
                                }
                            }
                        }
                    }
                }
            }
        }
        return csvdt;
    }
      
