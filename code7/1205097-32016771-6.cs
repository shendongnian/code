    public class Student
    {
        public int Id { get; set; }
        //...
        public int CityId { get; set; } //from City
        public virtual City City{get;set;}
    }
    
    public class City
    {
        public int Id { get; set; }
        //...
        public int StateId { get; set; } //from State
      
         public virtual City City{get;set;}
         public virtual ICollection<Student> Students{get;set;}
    }
    
    public class State
    {
        public int Id { get; set; }
        //...
        public int CountryId { get; set; } //from Country
        public virtual Country Country {get;set;}
        public virtual ICollection<City> Cities{get;set;}
    }
    
    public class Country
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public virtual ICollection<State> States{get;set;}
    }
