    namespace RockPaperScissors
    {
        enum GameAction
        {
            Rock,
            Paper,
            Scissors
        }
    
        abstract class Player
        {
            public abstract GameAction Act();
        }
    
        class PlayerRock : Player
        {
            public override GameAction Act()
            {
                return GameAction.Rock;
            }
        }
