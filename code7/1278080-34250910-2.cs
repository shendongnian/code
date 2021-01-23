    public class BrokenQuestion : BaseQuestion
    {
    } 
    public class BrokenGame : BaseGame<BrokenQuestion>
    {
    }
    var brokenGame = (BrokenGame)game;
    brokenGame.Add(new BrokenQuestion());`
