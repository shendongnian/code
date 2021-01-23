    foreach (string s in stringlist)
    {
        if (s.Contains(userinput))
        {
            Console.WriteLine("{0} is a substring of {1}", userinput, s);
        }
    }
