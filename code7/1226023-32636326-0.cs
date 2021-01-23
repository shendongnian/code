    class Program
    {
        static void Main(string[] args)
        {
            var a = 1;
            var b = 2;
            int u1, c1, u2, c2;
            unchecked
            {
                u1 = a + b;
            }
            checked
            {
                c1 = a + b;
            }
            unchecked
            {
                u2 = a + b;
            }
            checked
            {
                c2 = a + b;
            }
        }
    }
