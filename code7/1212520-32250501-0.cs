    public class C : A, B
    {        
        public void DoStuff<T>()
        {
            // ... DoStuff<T> implementation here ...
        }
    
        void A.DoStuff()
        {
            Console.WriteLine("A");
        }
    
        void B.DoStuff()
        {
            Console.WriteLine("B");
        }
    
        public void DoStuffAsA() { ((A)this).DoStuff(); }
        public void DoStuffAsB() { ((B)this).DoStuff(); }
    }
