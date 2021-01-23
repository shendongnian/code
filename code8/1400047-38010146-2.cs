    public class Test
    {
        public Test() { }
        public int Sum(int a, int b)
        {
            return a + b;
        }
        public void SumJob(int a, int b)
        {
            var result = Sum(a, b);
            Console.WriteLine(result);
        }
    }
