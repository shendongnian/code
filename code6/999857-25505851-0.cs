    public interface IGameLibrary 
    {
      [Recordset(1, typeof(User), Id = "GameId", IsChild = true)]
      IList<Game> GetGamesAndUsers();
    }
