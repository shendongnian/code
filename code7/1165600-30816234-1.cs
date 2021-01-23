    static int GetPlayers()
    {
        int? players;
    
        Console.Write("How many people are playing?");
    
        while (players == null)
        {
          try
          {
              players = Convert.ToInt16(Console.ReadLine());
          }
          catch (Exception e)
          {
              Console.Write(e.Message + "\n" + "----------");
          }
        }
    
        return players.Value;
    }
