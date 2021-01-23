            var query = from row in rpTable.AsEnumerable()
                        group row by int.Parse(row.Field<string>("Account")) into grp
                        orderby grp.Key
                        select new
                        {
                            Id = grp.Key,
                            Sum = grp.Sum(r => r.Field<decimal>("Payment"))
                        };
            foreach (var grp in query)
            {
                rpTable.Select("Account ="+grp.Id).ToList<DataRow>().ForEach(r=>r["Payment"] = grp.Sum);
            }
