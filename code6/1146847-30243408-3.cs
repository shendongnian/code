    foreach(var room in Rooms)
    {
      foreach(var roomContents in room.RoomContents)
      {
        Console.WriteLine("The commands for {0}",roomContents.Name);
        foreach(var command in roomContents.SupportedCommands)
        {
          Console.Writeline("{0}",command);
        }
      }
    }
