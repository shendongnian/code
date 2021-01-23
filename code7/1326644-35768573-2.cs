    public class Derived : MyBase
    {
        protected override void DoSomethingElse()
        {
            Console.WriteLine("Derived implementation");
        }
    }
    public static void Main(String[] args)
    {
        var derived = new Derived();
        derived.DoSomething();      //Base Implementation
        derived.DoSomethingElse();  //Derived implementation
    }
