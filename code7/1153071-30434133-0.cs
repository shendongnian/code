                var resultPCT = from row in dtNewL3.AsEnumerable()
                                group row by row["ID"]
                                    into g 
                                    select new
                                    {
                                        Group = g.FirstOrDefault().Field<string>("Group"),
                                        Dept = g.FirstOrDefault().Field<string>("Dept"),
                                        CommCode = g.Key,
                                        NewPCT = g.Sum(x => int.Parse(x["Percentage"].ToString()))
                                    };​
