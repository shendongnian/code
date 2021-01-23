    class Person:IEquatable<Person>
    {
     public int Id{get;set;}
     public bool Equals(Person other)
     {
    
    return Id== other.Id;
    }
    }
.
.
    List<Person> a = new List<Person> {
      new Person {
        Id = 1    
      }
    };
    
    List<Person> b = new List<Person> {
      new Person {
        Id = 1    
      }
    };
    
    var r = a.SequenceEqual(b);
