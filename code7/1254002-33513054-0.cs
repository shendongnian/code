    public void ReadCSV()
    {
        var reader = new StreamReader(File.OpenRead(@"C:\data.csv"));    
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            string[] values = line.Split('your separator');
    
            foreach(string item in values)
            {
                Console.WriteLine(item);
            }
        }
    }
