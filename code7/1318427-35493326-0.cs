    public DateTime GetDateTime()
    {
        DateTime ret;
        while (true)
        {
            Console.Write("Date? ");
            var dte = Console.ReadLine();
            if (DateTime.TryParse(dte, out ret))
                return ret;
        }
    }
