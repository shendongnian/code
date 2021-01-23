    public class Person
    {
        public int PersonID {get;set;}
        public string Name { get; set; }
        public List<Car> Cars {get;set;}
    }
    public class Car
    {
        public int CarID { get; set; }
        public string Name { get; set; }
        public int PersonID {get;set;}
    }
