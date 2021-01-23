     public class personnel
        {
            public String Name { get; set; }
            public String Family { get; set; }
            public String EmployTypecode { get; set; }
            public String employtypeName { get; set; }
            public String EmplytyppeTye { get; set; }
        }
    List<personnel> personnels = dbentities.Database.SqlQuery<personnel>(@"select 
        p.Name, p.Family,
        E.EmployTypecode, E.employtypeName, E.EmplytyppeTye 
    from 
        personnel as p
    left join 
        Employee as E on E.EmployTypecode = p.EmployTypecode ").ToList();
