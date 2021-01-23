    for (int i = 0; i < ListA.Count(); i++)
    {
        for (int j = 0; j < ListB.Count(); j++)
        {
            DateTime aItem = DateTime.ParseExact(ListA[i], "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime bItem = DateTime.ParseExact(ListB[i], "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        
            if (aItem.ToString("HH:mm") == bItem.ToString("HH:mm"))
                Console.WriteLine("Match Found");
        }
    }
