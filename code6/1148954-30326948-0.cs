    public DataTable GetResultsTable()
    {
        DataTable table = new DataTable();
        table.Columns.Add("Name".ToString());
        table.Columns.Add("Color".ToString());
        DataRow dr = table.NewRow();
        dr["Lesson"] = "Programing";
        dr["Calculus"] = "99";
       dr["result"] = "pass";
        table.Rows.Add(dr);
        return table;
    }
    public void gridview()
    {          
        datagridview1.DataSource =  GetResultsTable();
    }
