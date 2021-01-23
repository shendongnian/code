    var query = from r1 in Table1.AsEnumerable()
                join r2 in Table2.AsEnumerable()
                on r1.Field<long>("ID") equals r2.Field<long>("ID")
                join r3 in Table3.AsEnumerable()
                on r2.Field<long>("ID") equals r3.Field<long>("ID")
                select new {
                    ID = r1.Field<long>("ID"),
                    ParamX = r1.Field<string>("ParamX"),
                    ParamA = r3.Field<double>("ParamA"),
                    ParamB = r3.Field<short>("ParamB"),
                    ParamC = r3.Field<double>("ParamA") * r3.Field<short>("ParamB")
                };
    var Table4 = new DataTable();
    Table4.Columns.Add("ID", typeof(long));
    Table4.Columns.Add("ParamX", typeof(string));
    Table4.Columns.Add("ParamA", typeof(double));
    Table4.Columns.Add("ParamB", typeof(short));
    Table4.Columns.Add("ParamC", typeof(double));
