    using (StreamReader sr = new StreamReader("inputFile.txt")) 
    using (StreamWriter sw = new StreamWriter("outputFile.txt"))
    {
        string line1;
        int counter = 0;
        while ((line1 = sr.ReadLine()) != null) 
        {
            var line2 = sr.ReadLine();
            var line3 = sr.ReadLine();
            var groupedLine = line1 + line2 + line3; //whatever your grouping logic is
            sw.WriteLine(groupedLine);
        }
    }
    
