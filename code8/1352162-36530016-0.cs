    public class Person
    {
       // ... Name, Id, Age properties...
       public void CopyFrom(Person p)
       {
          this.Name = p.Name;
          this.Id = p.Id;
          this.Age = p.Age;
       }
    }
