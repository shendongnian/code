    public static void PermuteAndSolve(List<City> cities, int recursionLevel, int Length)
        {
            if (recursionLevel == Length)
            {
                foreach (City city in cities)
                {
                    Console.Write(city.name);
                }
                Console.WriteLine("");
            }
            else
            {
                for (int i = recursionLevel; i <= Length; i++)
                {
                    swap(cities, recursionLevel, Length);
                    PermuteAndSolve(cities, recursionLevel + 1, Length);                    
                }
            }
        }
