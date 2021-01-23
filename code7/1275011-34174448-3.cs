    public DataTable sortData(string columnName)
    {
       DataTable dt1=new DataTable();
       return  dt1=dataMgr[DatabaseFileNames.ControlDatabase]["OrderedTableName"]
                  .Select("Department='CSC'")
                  .OrderBy(x => x.Field<string>(columnName) ?? String.Empty,
                                new MyComparer(columnName)
                          )
                  .CopyToDataTable();
    }
