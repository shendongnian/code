    static void Main(string[] args)
        {
            string[] fileContents;
    
            try
            {
                fileContents = File.ReadAllLines(@"C:\temp\log.txt");
    
                foreach (string line in fileContents)
                {
                    Console.WriteLine(line);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                throw e;
            }
            //Here is my extra one line code            
            Console.ReadLine();
        }
