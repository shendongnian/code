    public abstract class Person
    {
       public string Name{get;set;}
       public virtual string SaySomething()
       {
          return = "Hello, my name is " + Name + ". ";
       }
    }
    public abstract class Employee : Person
    {
       public string Employer{get;set;}
    
       public override string SaySomething()
       {
          return base.SaySomething() + "I work for " + Employer + ". ";
       }
    }
    
    public class Engineer : Employee
    {
       public string Discipline{get;set;}
    
       public override string SaySomething()
       {
          return base.SaySomething() + "My discipline is " + Discipline + ". ";
       }
    }
