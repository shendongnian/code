    DataTable dtResult = new DataTable();
    dtResult.Columns.Add("ID", typeof(string));
    dtResult.Columns.Add("name", typeof(string));
    
    
    var result = from datatable1 in table1.AsEnumerable()
                 join datatable2 in table2.AsEnumerable()
                 on datatable1.Field<string>("ID") equals datatable2.Field<string>("userID")
    
                 select dtResult.LoadDataRow(new object[]
                 {
                    datatable1.Field<string>("ID"),               
    		string.Format("{0} {1}" ,datatable1.Field<string>("fname") ,datatable1.Field<string>("lname")),
                   
                  }, false);
    result.CopyToDataTable();
