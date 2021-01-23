    class Program
    {
        static void Main(string[] args)
        {
            bool nextLineToPrint = false;
            using (StreamReader sr = new StreamReader("c:/temp/ESMDLOG.csv"))
            {
                string currentLine;
                // currentLine will be null when the StreamReader reaches the end of file
                while ((currentLine = sr.ReadLine()) != null)
                {
                    if (nextLineToPrint)
                    {
                        Console.WriteLine(currentLine);
                        nextLineToPrint = false;
                    }
                    // Search, case insensitive, if the currentLine contains the searched keyword
                    if (currentLine.IndexOf("I/RPTGEN", StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        Console.WriteLine(currentLine);
                        nextLineToPrint = true;
                    }
                }
            }
            Console.ReadLine();
        }
    }
