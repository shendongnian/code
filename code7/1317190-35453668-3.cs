    public class Dog{
    
     public string Name { get; set; } // use public properties not fields
     public int Age { get; set; }     // use public properties not fields
    
     //...
     public bool IsAgeKnown { get; set; }
    
      public Dog(string n, int age){
        this.IsAgeKnown = true;
        this.Name = n;
        this.Age = age;
     }
    }
