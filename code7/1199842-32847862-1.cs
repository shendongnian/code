    static void Main(string[] args)
    {
        MyBaseClass myClass = new MyClass();
        MyBaseClass myAnotherClass = new MyAnotherClass();
        ClassThatIsUsingBaseClass.PrintName(myClass);
        ClassThatIsUsingBaseClass.PrintName(myAnotherClass);
        ClassThatIsUsingBaseClass.PrintNameMultiDispatch(myClass);
        ClassThatIsUsingBaseClass.PrintNameMultiDispatch(myAnotherClass);
        Console.ReadLine();
    }
