    public abstract class RootClass
    {
        public virtual void DoSomething()
        {
            Console.WriteLine("I'm doing something in the root class");
        }
    }
    
    public class ChildClass1 : RootClass
    {
        public void SomethingElse()
        {
            DoSomething(); //Prints out "I'm doing something in the root class"
        }
    }
    
    public class ChildClass2 : RootClass
    {
        public void SomethingElse()
        {
            DoSomething(); //Prints out "I'm doing something in ChildClass2
        }
    
        public override void DoSomething()
        {
            Console.WriteLine("I'm doing something in ChildClass2");
        }
    }
