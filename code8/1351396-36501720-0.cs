    class Foo
    {
        private static Foo instance;
        private System.IO.StreamWriter os;
        private Foo()
        {
            this.os = new System.IO.StreamWriter("D:/tmp/test.txt");
        }
        public static Foo Instance
        {
            get
            {
                if (instance == null)
                    instance = new Foo();
                return instance;
            }
        }
        public void Log(string s)
        {
            os.WriteLine(s);
            os.Flush();
        }
        public void Log2(string s)
        {
            System.IO.File.AppendAllText(@"D:/tmp/test2.txt",s);
       }
    }
