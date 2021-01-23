    using (StreamReader sr = new StreamReader("test.csv", ASCIIEncoding.UTF8))
    {
        while (!sr.EndOfStream)
        {
            Console.WriteLine("D1103SL".Equals(sr.ReadLine()));
        }
    }
