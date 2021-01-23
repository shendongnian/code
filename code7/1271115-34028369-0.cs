    using (StreamReader reader = File.OpenText(path1))
    {
        using (StreamWriter writer = File.AppendText(path2))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                
                //Console.WriteLine(line); //Uncomment this line if you want to write the line to the console
               
                writer.WriteLine(line);
            }
        }
    }
