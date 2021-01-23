    var results = from row in copyFrom.AsEnumerable()
                  group row by new
                  {
                    oid = row.Field<int>("oid"),// Or string, depending what is the real type of your column
                    idate = row.Field<DateTime>("idate")
                  } into g
                  select new
                  {
                     g.Key.oid,
                     g.Key.idate,
                     SumOfAmounts=g.Sum(e=>e.Field<decimal>("amount"));
                  };
