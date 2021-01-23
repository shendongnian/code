    static void Main()
    {
        using(StreamReader reader = new StreamReader(@"d:\input.txt"))
        using(StreamWriter writer = new StreamWriter(@"d:\output.txt"))
        {
            string line;
    
            // Write first line
            line = reader.ReadLine();
            writer.WriteLine(line);
    
            // Read the second line
            string second = reader.ReadLine(); ;
    
            // Skip 3rd & 4th lines
            for (int i = 0; i < 2; i++)
            {
                reader.ReadLine();
            }
    
            // Write 5th line
            line = reader.ReadLine();
            writer.WriteLine(line);
    
            // Write the 2nd line
            writer.WriteLine(second);
        }
    }
