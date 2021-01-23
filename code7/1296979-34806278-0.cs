    var pay = from p in lam.Mytablename.AsEnumerable()
              let maxid = lam.Mytablename.AsEnumerable().Max(x => x.Field<int>("Id"))
              where p.Date > start && p.Date < end && p.Field<int>("id") == maxid 
              select new
                    {
                        Column1= p.col1,
                        Coulumn2= p.col2,
                        Coulumn3= p.col2,
                        Coulumn4= p.col2
                    };
