    class Person
    {
       public Person(Person rhs) // cctor
       {
           Age = rhs.Age;
       }
       public int Age { get; set; }
       public abstract Person Clone();
    }
       public class Adult : Person
       {
           public Adult(Adult rhs) : base(rhs)
           {
               JobType = rhs.JobType;
           }
           public JobType Job { get; set; }
           public override Person Clone() { return new Adult(this); }
       }
