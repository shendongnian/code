    public abstract class A
    {
    }
    public class B : A
    {
        public B()
        {
            Console.WriteLine("I am of type B!");
        }
    }
    public class C : A
    {
        public C()
        {
            Console.WriteLine("I am of type C!");
        }
    }
    static List<A> listOfStuff = new List<A>();
    public static void doSomething()
    {
        listOfStuff.Add(new B());
        listOfStuff.Add(new C());
        foreach (A item in listOfStuff)
        {
            doOperation(item);
        }
    }
    static void doOperation(A thing1)
    {
        if (thing1 is B)
        {
            //Do code for B
        }
        if (thing1 is C)
        {
            //Do code for C
        }
    }
