     var q = (from p in commDs.Tables[1].AsEnumerable()
                         join e in ds.Tables[1].AsEnumerable()
                         on new {JobID = p.Field<int>("JobID"), EventID = p.Field<int>("EventID") }
                           equals new {JobID = e.Field<int>("JobID"), EventID = e.Field<int>("EventID") }
            select new {p,e}
            );
