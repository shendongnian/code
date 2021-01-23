    while ((line = sr.ReadLine()) != null)
    {
        if (line.Contains("tst")) {
            string line = line.Replace("tst", "");
            Console.WriteLine(line);
        }
    }
