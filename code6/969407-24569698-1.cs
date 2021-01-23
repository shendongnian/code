    DataTable table = new DataTable();
    DataColumn colID = table.Columns.Add("Id", typeof(int));
    DataColumn colFileName = table.Columns.Add("FileName", typeof(string));
    DataColumn colContent = table.Columns.Add("Content", typeof(string));
    
    string source = "1#3.doc#0.036\n2#1.doc#0.026\n";
    
    string[] lines = source.Split('\n');
    
    foreach(var line in lines)
    {
        string[] split = line.Split('#');
    
        DataRow row = table.NewRow();
    
        row.SetField(colID, int.Parse(split[0]));
        row.SetField(colFileName, split[1]);
        row.SetField(colContent, split[2]);
    
        table.Rows.Add(row);
    }
