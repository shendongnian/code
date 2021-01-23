    DateTime AquariusStart = new DateTime(DateTime.Now.Year, 01, 20);
    DateTime AquariusEnd = new DateTime(DateTime.Now.Year, 02, 18);
    DateTime UserBd = new DateTime(DateTime.Now.Year, 02, 19);
    if (DateTime.Compare(AquariusStart, UserBd) < 0 &&
        DateTime.Compare(AquariusEnd, UserBd) >= 0)
    {
         Console.WriteLine("Your Star Sign is Aquarius!");
    }
