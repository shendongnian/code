    class Program
    {
        static void Main(string[] args)
        { 
            Settings.Default.RunCount += 1;
            Settings.Default.Save();
            Console.WriteLine(String.Format("This is run number {0} for this user", Settings.Default.RunCount));  
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();  
        }
    }
