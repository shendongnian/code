    public class AlphaCygni : StarSystem
    {
        private static int mineral = 0;
        public static int Income(int a)
        {
            // Here with int mineral, you can see it starts at 0 but each addition with a (hydrogenIncome) should increase the number.
            mineral += a
            Console.WriteLine(mineral);
            return mineral;
            // The result of the addition returns mineral
        }
    }
