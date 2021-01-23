    public class Dog
    {
        public  string  Name;
        public  int     Age;
    }
    public class Cat
    {
        public  string  Name;
        public  decimal Weight;
    }
    public class Fish
    {
        public  Guid    Id;
        public  string  Name;
    }
    public class MyObject
    {
         public IEnumerable<Cat>  Cats { get; set; }
         public IEnumerable<Dog>  Dogs { get; set; }
         public IEnumerable<Fish> Fish { get; set; }
    }
