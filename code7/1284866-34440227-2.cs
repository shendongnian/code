    public class Poco
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
    
    var listA = new List<Poco> { new Poco { Name = "Var1", Value = 2.67 } };
    var listB = new List<Poco> { new Poco { Name = "Var1", Value = 4.32 } };
    
    var merged = (from a in listA
                  join b in listB on a.Name equals b.Name into tempGroup
                  from a2 in tempGroup.DefaultIfEmpty()
                  select a2 == null ? a : new Poco { Name = a.Name, Value = a.Value + a2.Value });
