    StringBuilder errors = new StringBuilder();   //// this will hold the record for those array which have length greater than the 6
    
    foreach (string csvRow in ReadCSV.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(csvRow))
                        {
                            //Adding each row into datatable  
                           DataRow dr = tblcsv.NewRow(); and then  
                            int count = 0;
                            foreach (string FileRec in csvRow.Split('-'))
                            {
                         try
                          {
                               dr[count] = FileRec;
                                tblcsv.Rows.Add(dr);
                          }
                         catch (IndexOutOfRangeException i)
                         {
                         error.AppendLine(csvRow;)
                         break;
                         }
                                count++;
                        }
                        }
                    }
