    public class A : IMy
    {
        public void F()
        {
            Console.WriteLine("A");
        }
    }
    
    public class B : A
    {
        public new void F() // <--- Note 'new' here
        {
            Console.WriteLine("B");
        }
    }
