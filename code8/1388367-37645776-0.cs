    public void numOfOtherMissions(List<Game> something)
    {
        var grouped = something.ToLookup(x => x.GameNo, x => x.FirstName);
        //Create a dictionary that holds the number of games for each person
        var gamesForPerson =
            something
            .GroupBy(x => x.FirstName)
            .ToDictionary(x => x.Key, x => x.Count());
        foreach (IGrouping<int, string> item in grouped)
        {
            Console.Write(item.Key);
            Console.Write(": ");
                
            foreach (var value in item)
            {
                //Get total number of games for this person and subtract 1
                var othergames = gamesForPerson[value] - 1;
                Console.Write(value + " " + othergames);
                Console.WriteLine();
            }
        }
    }
