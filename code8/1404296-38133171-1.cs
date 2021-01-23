    int counter = 0;
    using (TextReader tr = new StreamReader(__inputfile))
    {
        string nextline = tr.ReadLine();
        while (nextline != null)
        {
            counter++;
            if(counter == 100)
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                counter = 0;
            }
    
            Console.WriteLine(nextline);
            nextline = tr.ReadLine();
               
        }
    }
