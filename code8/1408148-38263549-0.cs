    public class Vehicle 
    {
        public string Foo {set; get;}
        public string Bar {set; get;}
    }
    var filterValues = new List<string>();
    vehicles.Select(x => filterValues.Any(f => f.Contains(x.Foo) ||
                         filterValues.Any(f => f.Contains(x.Bar))
                         .ToList();
