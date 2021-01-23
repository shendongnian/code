    private static void Main(string[] args)
    {
        string filePath = @"C:\temp\tesst.csv";
        FileStream filestream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
    
        DataTable inputTable = new DataTable();
    
        using (StreamReader reader = new StreamReader(filestream, Encoding.UTF8))
        {
    
            //Get headers and add columns
            string headers = reader.ReadLine();
            foreach (var s in headers.Split(','))
            {
                inputTable.Columns.Add(s, typeof (string));
            }
                    
            //Add rows
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int colIndex = 0;
                DataRow dr = inputTable.NewRow();
                foreach (var s in line.Split(','))
                {
                    dr[colIndex] = s;
                    colIndex++;
                }
                inputTable.Rows.Add(dr);
            }
        }
    }
