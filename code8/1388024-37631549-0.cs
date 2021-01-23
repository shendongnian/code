    internal class A
    {
    	internal virtual void Test() => Console.WriteLine("A.Test()");
    }
    
    internal class B : A
    {
    	internal override void Test() => Console.WriteLine("B.Test()");
    }
