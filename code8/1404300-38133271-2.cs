    using (TextReader tr = new StreamReader(__inputfile))
    {
        var count=1;
        string nextline = tr.ReadLine();
        while (nextline != null)
        {
            if (count % 100 == 0)
            {
                Console.WriteLine("Press Enter to continue...or Control-C to stop");
                nextline=Console.ReadLine();
                Console.WriteLine(nextline);
            }
            else
            {
                Console.WriteLine(nextline);
                nextline = tr.ReadLine();
            }
            count++;
        }
    }
