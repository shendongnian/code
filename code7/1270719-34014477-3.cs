    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Version v = new Version();
                v.GetVersion();
                //do stuff with nbuversion - 1st way
                Console.WriteLine("1:" + v.nbuversion);
                //do stuff with nbuversion - 2nd way
                v.DoStuff();
            }
        }
        public class Version
        {
            public string nbuversion { get; set; }
            public void  GetVersion()
            {
                Console.WriteLine("Enter the Version:"); // Prompt for version
                //string nbuversion = Console.ReadLine(); <- this will Readline into local variable - WRONG
                nbuversion = Console.ReadLine();
            }
            public void DoStuff()
            {
                Console.WriteLine("2:" + nbuversion);
                //do stuff with nbuversion
            }
        }
    }
