    void Main()
    {
            var personTables = new List<Persontable>{
    		new Persontable{Name = "John", AllApartments = new List<int>{1, 2, 3}, Active = false},
    		new Persontable{Name = "Mary", AllApartments = new List<int>{1}, Active = true},
    	};
    	
    	var apartments = new List<Apartment>{
    		new Apartment { Id = 1, Name = "LA downtown apts"},
    		new Apartment { Id = 2, Name = "NYC downtown apts"},
    	};
    	
    	var result = personTables.Select( p => new PersontableAparment{
    		Name = p.Name,
    	    AllApartmentsNames = apartments.Where(a => p.AllApartments.Contains(a.Id)).Select(x => x.Name).ToList(),
    		Active = p.Active,
    	});
    }
    
    public class Persontable
    {
    	public string Name { get; set;}
    	public List<int> AllApartments { get; set;}
    	public bool Active {get; set;}
    }
    
    public class Apartment
    {
    	public int Id {get; set;}
    	public string Name {get; set;}
    }
    
    public class PersontableAparment 
    {
        public string Name { get; set; }
        public List<string> AllApartmentsNames { get; set; }
        public bool Active { get; set; }
    
    }
