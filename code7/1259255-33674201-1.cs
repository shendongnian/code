    private List<string> DemoDistinct()
    {
        List<string> dateList = new List<string>();
        DataTable dt = new DataTable();
    
        using (OleDbConnection cn = new OleDbConnection { ConnectionString = ConnectionString(System.IO.Path.Combine(Application.StartupPath, "WS1.xlsx"), "Yes") })
        {
            cn.Open();
    
            using (OleDbCommand cmd = new OleDbCommand
            {
                CommandText = "SELECT DISTINCT [Dates] FROM [Sheet2$]",
                Connection = cn
            }
             )
            {
                OleDbDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dateList = dt
                    .AsEnumerable()
                    .Select(row => row.Field<DateTime>("Dates").ToShortDateString()).ToList();                      
            }
        }
    
        return dateList;
    }
