            System.Data.DataTable table = new System.Data.DataTable("dataFromFile");
            string file="textfile.txt" ==>Get file which you want to split into columns
           
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                int rowsCount = 0;
                while ((line = sr.ReadLine()) != null)
                {
                   
                    string[] data = line.Split(new string[] { "\t"," " }, StringSplitOptions.RemoveEmptyEntries);==>here i'm using the tab delimeter to split the row line
                                                                                                                ==>in the file to columns data,You can use your own delimeter
                    if(table.Columns.Count==0)
                    { 
                    for (int i = 1; i <= data.Length; i++)
                    {
                        table.Columns.AddRange(new DataColumn[] { new DataColumn("col"+(i).ToString(), typeof(string)) });==>here i'm dynamically creating the column headers
                                                                                                                          ==> based on  the strings in the line
                    }
                    }
                    table.Rows.Add();
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i].Contains(" "))
                            data[i] = data[i].Replace(" ", "");
                        if (!data[i].Equals(""))
                            table.Rows[rowsCount][i] = data[i];
                    }
                    rowsCount++;
                }
            }
            return table;
        }
