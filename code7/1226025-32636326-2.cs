    class Program
    {
        static void Main(string[] args)
        {
            var a = 1;
            var b = 2;
            int u1, c1, u2, c2, u3, c3;
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
                u2 = Add(a, b);
            }
            checked
            {
                c2 = Add(a, b);
            }
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
    }
