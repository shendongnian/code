        using System.IO;
        
        var dt = new DataTable();
        dt.Columns.Add("Nr", typeof(int));
        //...your columns
        dt.Columns.Add("Notite", typeof(string));
        
        using (StreamReader reader = new StreamReader(FilePath))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                string[] Elements = line.Split('yourSplit');
                                DataRow row = myDataTable.NewRow();
                                row[0] = Elements[0];
                                //....
                                row[5] = Elements[5]; //depends on Elements
                                myDataTable.Rows.Add(row);
                            }
                        }
        foreach(DataRow row in myDataTable.Rows)
         { 
             textbox1.Text += row["col1"].ToString();  
              ///
             textbox2.Text += row["col2"].ToString();
         }
        
    //save
    
     private void btnSave_Click(object sender, RoutedEventArgs e)
            { 
                using (StreamWriter writer = new StreamWriter(Path))
                {
                    foreach (DataRow row in myDataTable.Rows)
                    {
                        string line = string.Format("\"{0}\"_\"{1}\"_\"{2}\"_\"{3}\"_\"{4}\"_\"{5}\"", row[0], row[1], row[2], row[3], row[4], row[5]);//or your format
                        writer.WriteLine(line);
                    }
                }
            }
