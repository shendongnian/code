    public class Calc
    {
        public int IdCalc { get; set; }
        public double Result { get; set; }
        public int Number { get; set; }
    }
    public class Program
    {
        static void Main()
        {
            Calc myC1 = new Calc();
            List<Calc> liCalc = new List<Calc>();
            myC1.IdCalc = -1;
            myC1.Result = 20.2;
            myC1.Number = 1;
            Calc myC2 = new Calc();
            myC2.IdCalc = 22;
            myC2.Result = 20.2;
            myC2.Number = 2;
            liCalc.Add(myC1);
            liCalc.Add(myC2);
            double getResult = liCalc.First(item => item.IdCalc == 22 && item.Number == 2).Result; //Note that this will throw an exception if no item in the list satisfies the condition.
            Console.ReadKey();
        }
