    var pay = from p in lam.Mytablename.AsEnumerable()
              let maxid = lam.Mytablename.AsEnumerable().Max(x => x.Field<int>("Id"))
              where p.Date > start && p.Date < end && p.Field<int>("id") == maxid 
              select new
                    {
                        Column1 = p.col1,
                        Column2 = p.col2,
                        Column3 = p.col2,
                        Column4 = p.col2
                    };
