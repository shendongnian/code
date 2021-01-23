        String dateString = "20160622";
        string year = dateString.Substring(0, 4);
        Console.WriteLine("year is " +year);
        Console.ReadKey();
        string month = dateString.Substring(4, 2);
        Console.WriteLine("month is " + month);
        Console.ReadKey();
        string jour = dateString.Substring(6, 2); // i think you mean `day`
        Console.WriteLine("day is  " + jour);
        Console.ReadKey();
