    List<string> ColumnValues = new List<string>();
                    for (int n = 2; n < rowCount; n++)
                    {
                        for (int m = 1; m < colCount; m++)
                        {
                            Excel.Range some = worksheet.UsedRange.Columns[m];
    
                            System.Array myvalues = (System.Array)some.Cells.Value;
                            string[] Data = myvalues.OfType<object>().Select(o => o.ToString()).ToArray();
                            ColumnValues = Data.ToList();
                            System.Console.WriteLine(ColumnValues);
                            //String Types
                            if (ColumnValues.Contains("Name"))
                            {
                                string tagval = "Product_Array[0].Name";
                                string[] result = ColumnValues.Skip(1).ToArray();
    
                            }
     
                                            
                        }
    
    
                    }
    
            }
