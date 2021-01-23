    static void Main(string[] args)
    {
        TestForPoBox("PO BOX 111");
        TestForPoBox("P.O. Box 222");
        TestForPoBox("p.O. boX 333");
        TestForPoBox("444 Main Street");
        Console.ReadKey();
    }
    static void TestForPoBox(string streetAddress)
    {            
        const string pattern = "(?i)^(?!.*p\\.?o\\.?\\s+?box).*$";
        Match match = Regex.Match(streetAddress, pattern);
        //Write out the matches
        if (match.Length > 0)
            Console.WriteLine("OK. Address is not a P.O. Box: " + streetAddress);
        else
            Console.WriteLine("INVALID. Address contains a P.O. Box: " + streetAddress);
    }
