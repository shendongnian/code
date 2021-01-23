    static int GetPlayers()
    {
        int players = 0;
        Console.Write("How many people are playing?");
        try
        {
            players = Convert.ToInt16(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.Write(e.Message + "\n" +
                "----------");
           return GetPlayers(); // return the result
        }
        return players;
    }
