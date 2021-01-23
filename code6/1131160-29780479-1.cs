    class Program
        {
            static void Main(string[] args)
            {
                StreamReader rw = new StreamReader("read.txt");
                string line = "";
                // This variable will store the current line number
                int currentLine = 0;
                while (line != null) 
                {
                    line = rw.ReadLine();
                    // Increase the line number
                    currentLine++;
                    // Check if the line is not null and if the line number is not between 10 and 19
                    if (line !=null && !(currentLine >= 10 && currentLine <= 19))
                    {
                        Console.WriteLine(line);
                    }
    
                }
                rw.Close();
                Console.ReadLine();
    
            }
        }
