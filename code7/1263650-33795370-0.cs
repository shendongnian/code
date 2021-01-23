    public abstract class Animal {
       public int NoOfLegs { get; set; } // example
    }
    
    public class Cat : Animal {
    }
    
    public class Dog : Animal {
    }
    
    List<Animal> q;
    
    Switch(petType)
    {
       case 1:
       q = from c in Cats
           where c.Type equals == 1
           select c;
       break;
       
       case 2:
       q = from d in Dogs 
           where d.Type equals == 1
           select d; 
       break;
    }
    foreach(var r in q)
    {
        //Do Stuff
    }
