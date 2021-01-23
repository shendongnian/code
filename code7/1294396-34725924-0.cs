    DataTable dtTextFileData = new DataTable();
    dtTextFileData.Columns.AddRange(new []
    {
        new DataColumn("First", typeof(string)), 
        new DataColumn("Second", typeof(string)) 
    });
    
    StreamReader file = new StreamReader(@"c:\YourFilePath\input.txt");
    string line = file.ReadLine();
    while (line != null)
    {
        string[] fields = line.Split('#');
        DataRow dr = dtTextFileData.NewRow();
        dr["First"]  = fields[0].ToString();
        dr["Second"] = fields[1].ToString();
        dtTextFileData.Rows.Add(dr);
        line = file.ReadLine();
    }
