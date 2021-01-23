     private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Name");
            dt.Columns.Add("Number");
            dt.Columns.Add("ID");
            dt.Columns.Add("License");
            string[] array = { "Max", "32445", "1", "KPFG35", "Bill", "33234", "2", "DGWEF9", "Ruth", "89428", "3", "SFD3FG" };
            for (int i = 0; i < array.Length + 1; i++)
            {
                
                if (i != 0 && i % 4 == 0)  // every 4th item should be split from list
                {
                    string[] tempArray = new string[4]; //temp array will keep every item until 4th one.
                    tempArray = array.Take(i).ToArray(); //Take until 4th item.
                    array = array.Skip(i).ToArray(); //then we don't need that items so we can skip them
                    dt.Rows.Add(tempArray); //Row is done.
                    i = -1; //Every skip will generate a new array so it should go back to 0.
                }
            }
            dataGridView1.DataSource = dt;
        }
