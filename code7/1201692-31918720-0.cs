    //abstract class to establish the presence of FooMethod, but not the functionality
    public abstract class FooBase {
        public abstract void FooMethod(FooBase obj);
    }
    //Implement FooBase so that Foo is guaranteed to have a FooMethod implementation
    public class Foo : FooBase
    {
        public Foo()
        {
        }
        public Foo(Foo x, Foo y)
        {
            ThisX = x;
            ThisY = y;
        }
        public Foo ThisX { get; set; }
        public Foo ThisY { get; set; }
        //Override FooMethod so that it can do whatever Foo needs it to do
        public override void FooMethod(FooBase ob)
        {
            Console.WriteLine("Hiiiii\t" + ob);
        }
    }
    public class Gen<T> where T : FooBase
    {
        T obj;
        public Gen()
        {
        }
        public Gen(T x, T y)
        {
            Console.WriteLine("Gen(T x,T y)\t" + x.GetType().Name.ToString() + " " + y.GetType().Name.ToString());//+" "+obj.GetType().Name.ToString());
        }
        public void Display(T ob)
        {
            obj = ob;
            Console.WriteLine("Display  " + ob.GetType().Name.ToString() + " " + obj.GetType().Name.ToString());
            //Fire the objests implementation of FooBase.FooMethod(FooBase obj)
            obj.FooMethod(obj);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Gen<Foo> m = new Gen<Foo>();
            Foo ob1 = new Foo();
            Foo ob2 = new Foo();
            Console.WriteLine("Main " + m.GetType());
            Console.WriteLine("Main " + ob1.GetType());
            Console.WriteLine();
            Gen<Foo> n = new Gen<Foo>(ob1, ob2);
            Console.WriteLine();
            m.Display(ob1);
            //To stop the console
            Console.ReadLine();
        }
    }
