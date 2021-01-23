    var matched = from table1 in oClone.AsEnumerable()
                  join table2 in mClone.AsEnumerable() on table1.Field<decimal>("CASEID") equals table2.Field<Int64>("CASEID")
                  where table1.Field<decimal>("CASEID") == table2.Field<Int64>("CASEID") || 
                  table1.Field<string>("CASENAME") == table2.Field<string>("CASENAME") || 
                  table1.Field<DateTime>("CREATEDDATE") == table2.Field<DateTime>("CREATEDDATE") || 
                  table1.Field<int>("STUDYMODEID") == table2.Field<int>("STUDYMODEID") || 
                  table1.Field<string>("ENVIRONMENT") == table2.Field<string>("ENVIRONMENT")
                  select table1;
    var missing = from table1 in oClone.AsEnumerable()
                  where !matched.Contains(table1)
                  select table1;
