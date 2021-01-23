    public DataTable CreateMyTableDatasource()
           {
               DataTable dt = new DataTable("dt");
               dt.Columns.Add("col1".ToString());
               dt.Columns.Add("col2".ToString());
               dt.Columns.Add("col3".ToString());
               dt.Columns.Add("col4".ToString());
               return dt;
           }
