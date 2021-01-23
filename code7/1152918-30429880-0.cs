    var res = from dr1 in table1.AsEnumerable()
                join dr2 in table2.AsEnumerable()
                  on dr1.Field<int>("ID") equals dr2.Field<int>("ID")
              select resultTable.LoadDataRow(new object[]
              {
                dr1.Field<int>("ID"),
                dr1.Field<string>("column name .. "),
                ... 
                dr2.Field<string>("column from table 2 .. "),
                ...
               }, false);
