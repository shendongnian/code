    static void Main()
    {
        using(StreamReader reader = new StreamReader(@"d:\input.txt"))
        using(StreamWriter writer = new StreamWriter(@"d:\output.txt"))
        {
            string line;
    
            // Write 1st line
            line = reader.ReadLine();
            writer.WriteLine(line);
                
            // Skip 3 lines
            for (int i = 0; i < 3; i++)
            {
                reader.ReadLine();
            }
            // Write 5th & 6th line
            for (int i = 0; i < 2; i++)
            {
                line = reader.ReadLine();
                writer.WriteLine(line);
            }
        }
    }
