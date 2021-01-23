    DataTable tbl = new DataTable();
    tbl.Columns.Add("Text");
    tbl.Columns.Add("Value");
    tbl.Columns.Add("FirstNamee");
    tbl.Columns.Add("LastName");
    tbl.Columns.Add("Addresss");
    
    foreach (DirectoryInfo folder in dirArr)
    {
        // not sure how you get these informations from the DirectoryInfo 
        tbl.Rows.Add(Text, Value, FirstNamee, LastName, Addresss);
    }
    GridView.DataSource = tbl;
    GridView.DataBind();
