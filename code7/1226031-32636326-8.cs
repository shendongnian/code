    class Program
    {
        static void Main(string[] args)
        {
            var a = 1;
            var b = 2;
            int u1, c1, u2, c2;
            Console.Write("unchecked add ");
            unchecked
            {
                u1 = a + b;
            }
            Console.WriteLine(u1);
            Console.Write("checked add ");
            checked
            {
                c1 = a + b;
            }
            Console.WriteLine(c1);
            Console.Write("unchecked call ");
            unchecked
            {
                u2 = Add(a, b);
            }
            Console.WriteLine(u2);
            Console.Write("checked call ");
            checked
            {
                c2 = Add(a, b);
            }
            Console.WriteLine(c2);
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
    }
