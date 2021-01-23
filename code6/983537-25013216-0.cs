    internal class NameValue
    {
        public string Name { get; set; }
    
        public double Value { get; set; }
    }
    
    var sourceList = new List<NameValue>
    {
        new  NameValue {Name = "A", Value = 6.5},
        new  NameValue {Name = "A", Value = 6.0},
        new  NameValue {Name = "B", Value = 6.5},
        new  NameValue {Name = "B", Value = 6.0},
        new  NameValue {Name = "C", Value = 7.75},
        new  NameValue {Name = "D", Value = 7.0}
    };
    
    var result = sourceList.GroupBy(x => x.Name)
       .Select(x => new
       {
         Name = x.Key,
         Value = x.Max(y => y.Value)
       });
