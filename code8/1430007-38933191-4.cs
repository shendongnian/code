    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            List<string> wordsTyped = new List<string>();
            // If the file already exists then you can load its content 
            // in memory to start your checks against the current content
            // of the file....
            if(File.Exists("lines.txt"))
                wordsTyped.AddRange(File.ReadAllLines("lines.txt"));
            for (;;)
            {
                Console.Write("Write phrase: (type 'exit' to end)");
                string row = Console.ReadLine();
                // Provide a way to exit from this infinite loop
                if(row == "exit")
                    break;
                Console.WriteLine(i++ + ". " + (row));
                
                // Use IndexOf to find if there is a match for your row 
                // and in which position in the List<string>
                int position = wordsTyped.IndexOf(row);
                if (position != -1)
                    Console.WriteLine($"Already inserted. Found match at line {position+1} , type again");
                else
                {
                    wordsTyped.Add(row);
                    // It of uttermost importance to enclose the StreamWriter
                    // in a using statement to be sure to close and dispose it
                    // after the write, otherwise you could lock yourself out
                    using(StreamWriter sw = File.AppendText("lines.txt"))
                      sw.WriteLine(row);
                }
            }
            // File.WriteAllLines("lines.txt", wordsTyped.ToArray());
            Console.Read();
        }
    }
