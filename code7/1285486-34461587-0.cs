    public class A 
    {
        protected void Test()
        {
            Console.WriteLine("I can only be called from B");
        }
    }
    public class B : A
    {
        public void Pub()
        {
            Test();
        }
    }
