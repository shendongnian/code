    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Some Stuff");
            GrowConsole();
        }
        const double TriggerGrowthPercentage = .90;
        const double GrowthPercentage = 1.25;
        private static void GrowConsole()
        {
            if (((double)Console.CursorTop)/Console.BufferHeight <= TriggerGrowthPercentage)
            {
                int growth = (int)(Console.BufferHeight*GrowthPercentage);
                growth = Math.Max(growth, 1); //Grow at least by 1;
                growth = Math.Min(growth, Int16.MaxValue - 1); //Don't grow bigger than Int16.MaxValue - 1;
                Console.BufferHeight = growth;
            }
        }
