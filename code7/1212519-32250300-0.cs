    class C : A, B
    {
        void B.DoStuff()
        {
            Console.WriteLine("B");
        }
        void A.DoStuff()
        {
            Console.WriteLine("A");
        }
        public void DoStuff<T>() 
        {
            var mi = typeof(T).GetMethod("DoStuff");
            mi.Invoke(this, new object[] { });
        }
    }
