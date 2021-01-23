    OpenFileDialog openFileDialog1 = new OpenFileDialog();//creation and inialization of open file dialog 
    
                openFileDialog1.InitialDirectory = @"C:\temp";// object of file dialog  sent to open file to default c drive
                openFileDialog1.Title = "Browse txt File";// text to show on the bar
    
                openFileDialog1.CheckFileExists = true;// check whether file exit
                openFileDialog1.CheckPathExists = true;//check file path
    
                openFileDialog1.DefaultExt = "txt";// the file default extensio
                openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";//filter by default to only txt files
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
    
                openFileDialog1.ReadOnlyChecked = true;
                openFileDialog1.ShowReadOnly = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)// prompt for a file dialog
                {
                    //read selected text file
                    string rawData = File.ReadAllText(openFileDialog1.FileName);
                    //split into rows, delimited by NewLine (\r\n)
                    string[] rows = rawData.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                    
                    //create dataTable
                    DataTable table = new DataTable();
                    table.Columns.Add("xValue", typeof(decimal));
                    table.Columns.Add("yValue", typeof(decimal));
    
                    foreach  (string row in rows)
                    {
                        //split each row by ',' which will give array of two elements
                        string[] values = row.Split(',');
                        //put those elements as column values. Make additional operations here if needed (instead of table.Rows.Add(values))
                        // ie. 
                        //DataRow row = table.NewRow(); 
                        //row[0] = values[0].Trim();
                        //... 
                        table.Rows.Add(values);
                        
                    }
    
                    //create series of data
                    chtSin.Series.Add("series");
                    //assign datatable column to series axis
                    chtSin.Series["series"].XValueMember = "xValue";
                    chtSin.Series["series"].YValueMembers = "yValue";
                    //pass this DataTable as chart source
                    chtSin.DataSource = table;
                    //databind
                    chtSin.DataBind();
                }
