    public class MyClass
    {
        public string Name{get;set;}
        public string Date{get;set;}
    }
    
    var noDups = firstTable.AsEnumerable()
                            .GroupBy(d => new
                            {
                                name = d.Field<string>("name"),
                                date = d.Field<string>("date")
                            })
                            .Where(d => d.Count() > 1) 
                            .Select(d => {
                                  var first = d.First();
                                  return new MyClass()
                                     {
                                         Name = (string)first["name"],
                                         Date = (string)first["date"]
                                     }
                             })
                             
                             .ToList();
