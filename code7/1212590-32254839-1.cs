    DataTable table1 = /*something*/ ;
    DataTable table2 = /*something*/ ;
    DataTable table3 = /*something*/ ;
    
    DataView result = (from t1 in table1.AsEnumerable() join 
                                        t2 in table2.AsEnumerable() on t1.Field<int>("id") equals t2.Field<int>("t1id") join
                                        t3 in table3.AsEnumerable() on t2.Field<int>("t3id") equals t3.Field<int>("id")
                                   where 666.Equals(t3.Field<int>("id"))
                                  select t1).CopyToDataTable<DataRow>().AsDataView();
