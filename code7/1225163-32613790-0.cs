    public class Program
    {
        private int _seedValue = 0; //invalid seed value, judging from your messages
        
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0 && Convert.ToInt32(args[0]) > 0)
                {
                    _seedValue = Convert.ToInt32(args[0]);
                }
                else
                {
                    Console.WriteLine("Please, use an integer greater than 0.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please, use an integer greater than 0:");
            }
        }
        public void ProcessSeed()
        {
            Console.WriteLine(_seedValue);
        }
    }
