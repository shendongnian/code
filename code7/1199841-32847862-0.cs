    public abstract class MyBaseClass
    {
    }
    public class MyClass : MyBaseClass
    {
    }
    public class MyAnotherClass : MyBaseClass
    {
    }
    public class ClassThatIsUsingBaseClass
    {
        public static void PrintName(MyBaseClass baseClass)
        {
            Console.WriteLine("MyBaseClass");
        }
        public static void PrintName(MyClass baseClass)
        {
            Console.WriteLine("MyClass");
        }
        public static void PrintName(MyAnotherClass baseClass)
        {
            Console.WriteLine("MyAnotherClass");
        }
        public static void PrintNameMultiDispatch(MyBaseClass baseClass)
        {
            ClassThatIsUsingBaseClass.PrintName((dynamic)baseClass);
        }
    }
