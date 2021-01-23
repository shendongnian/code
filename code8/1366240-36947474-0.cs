    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter N= ");
            int n = int.Parse(Console.ReadLine());
            int i = 1;
            int output = 1;
            while (i <= n)
            {
                output = output * i;
                i++;
            }
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
