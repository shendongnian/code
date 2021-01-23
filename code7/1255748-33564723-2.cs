    List<Articles> list = new List<Articles>() 
    {
       new Articles(){DateCreated=new DateTime(2015, 1, 18), Smth="aa1"},
       new Articles(){DateCreated=new DateTime(2015, 1, 18), Smth="aa2"},
       new Articles(){DateCreated=new DateTime(2014, 1, 18), Smth="aa3"},
       new Articles(){DateCreated=new DateTime(2014, 1, 18), Smth="aa4"},
       new Articles(){DateCreated=new DateTime(2016, 1, 18), Smth="aa5"},
       new Articles(){DateCreated=new DateTime(2016, 1, 18), Smth="aa6"},
       new Articles(){DateCreated=new DateTime(2012, 1, 18), Smth="aa7"},
       new Articles(){DateCreated=new DateTime(2012, 1, 18), Smth="aa8"},
       new Articles(){DateCreated=new DateTime(2018, 1, 18), Smth="aa9"},
       new Articles(){DateCreated=new DateTime(2018, 1, 18), Smth="aa10"},
    };
    var yourQuery = (from p in list group p.DateCreated by p.DateCreated into g select new { ByDate = g.Key, GroupedColl=g.ToList() }).OrderBy(x=>x.ByDate);
