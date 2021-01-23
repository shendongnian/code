    public static void PermuteAndSolve(List<City> cities, int Length)
    {
        int recursionLevel = 0;
        while(recursionLevel < Length)
        {
            for (int i = recursionLevel; i <= Length; i++) {
                swap(cities, recursionLevel, Length);
            }
            recursionLevel++;
        }
    
        foreach(City city in cities)
        {
            Console.Write(city.name);
        }
        Console.WriteLine("");
    }
