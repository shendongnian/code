    public abstract class Employee : Person
    {
       public string Employer{get;set;}
    
       protected override string OnSaySomething(string thoughts)
       {
          return base.OnSaySomething(thoughts)+ "I work for " + Employer + ".";
       }
    }
    
    public class Engineer : Employee
    {
       public string Discipline{get;set;}
    
       protected override string OnSaySomething(string thoughts)
       {
          return base.OnSaySomething(thoughts) + "My discipline is " + Discipline + ".";
       }
    }
