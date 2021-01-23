    namespace ConsoleApplication12
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Stream theFile = Assembly.GetExecutingAssembly().GetManifestResourceStream("ConsoleApplication12.test.txt");
                using (StreamReader fileUsage_1 = new StreamReader(theFile))
                {
                    Method1(fileUsage_1);
                    Method2(fileUsage_1);
                }
    
                Console.ReadLine();
            }
    
            private static void Method2(StreamReader fileUsage)
            {
                //fileUsage.BaseStream.Seek(0, SeekOrigin.Begin); //If needed
                var test = fileUsage.ReadLine();
            }
    
            private static void Method1(StreamReader fileUsage)
            {
                //fileUsage.BaseStream.Seek(0, SeekOrigin.Begin); //If needed
                var test = fileUsage.ReadLine();
            }
        }
    }
