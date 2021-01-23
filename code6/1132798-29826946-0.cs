    namespace All
    {
        public class X
        {
            public static void Read() { }
        }
        public class Y
        {
            public static void Write() { }
        }
    }
    
    
    namespace A
    {
        namespace First
        {
            public static class X
            {
                public static void Read()
                {
                    All.X.Read();
                }
            }
        }
    }
    
    namespace B
    {
        namespace Second
        {
            public static class Y
            {
                public static void Write()
                {
                    All.Y.Write();
                }
            }
        }
    }
