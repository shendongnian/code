    static void Main(string[] args)
        {
            int nu1, nu2, nu3, cavg;
            GetNums(out nu1, out  nu2, out nu3);
            double average = CalcAvg(nu1, nu2, nu3);
            DspAvg(average);
        }
        static void GetNums(out int nu1, out int nu2, out int nu3)
        {
            Console.Write("Please enter nu1: ");
            nu1 = int.Parse(Console.ReadLine());
            Console.Write("Please enter nu2: ");
            nu2 = int.Parse(Console.ReadLine());
            Console.Write("Please enter nu3: ");
            nu3 = int.Parse(Console.ReadLine());
        }
        static double CalcAvg(int nu1, int nu2, int nu3)
        {
            return (nu1 + nu2 + nu3) / 3;
        }
        static void DspAvg(double average)
        {
            Console.WriteLine(Math.Round(average, 2));
        }
