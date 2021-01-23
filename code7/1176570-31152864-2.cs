    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(">Enter File to open.");//Prompt user for file name
                string s = Console.ReadLine();
                try
                {
                    if (!File.Exists(s))
                        throw new FileNotFoundException();//Check for errors
                    else
                        System.Diagnostics.Process.Start(s); //set valid reply response
                    Console.ReadLine();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("You stuffed up!"); //Display error message
                }
            }
        }
    }
   
