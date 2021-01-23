    public class Result2 { 
        public User User {get;set};
        public Game Game {get; set;}
    }
    
    var gameId = 80; // Id of game by which you want to filter
    var newResults = results.Select(r => new Result2 {
        User = r.User,
        Game = r.Games.OrderByDescending(g => g.Points).FirstOrDefault(g => g.GameId == gameId)
    }.ToList();
