    // Open the stream and read it back.
    using (StreamReader sr = fi.OpenText())
    {
        string s = "";
        while ((s = sr.ReadLine()) != null) 
        {
            Console.WriteLine(s);
        }
    }
