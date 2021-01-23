    public class Dog{
    
     public string Name;
     public int Age;
    
     //...
     public bool IsAgeKnown { get; set; }
    
      public Dog(string n, int age){
        this.IsAgeKnown = true;
        this.Name = n;
        this.Age = age;
     }
    }
