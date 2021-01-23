    class SetPlayerData
    {
      public bool Check {get; set;}
      public SetPlayerData(bool check) { this.Check = check;}
    }
      private SetPlayerData SetPlayers(...)
    {
      ....
       SetPlayerData data = new SetPlayerData(true);
      ....
      return data; 
    }
