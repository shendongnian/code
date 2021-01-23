    public class Location
    {
        public string Name { get; set; }
    }
    
    public class Competence
    {
        public string Name { get; set; }
    }
    
    public class MyViewModel
    {
        public User User { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Competence> Competences { get; set; }
    }
