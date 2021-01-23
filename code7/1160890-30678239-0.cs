    class Foo
    {
        private bool m_Done = false;
        public void A()
        {
            Task.Run(() => { m_Done = true; });
        }
        public void B()
        {
            for (; ; )
            {
                if (m_Done)
                    break;
            }
            Console.WriteLine("finished...");
        }
    }
    class Program
    {
     
        static void Main(string[] args)
        {
            var o = new Foo();
            o.A();
            o.B();
            Console.ReadKey();
        }
    }
