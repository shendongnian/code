    namespace RockPaperScissors
    {
        class Program
        {
            private static void Main(string[] args)
            {
    
                var player1 = new PlayerPaper()
                {
                    Name = "Derek",
    
                };
    
                var player2 = new PlayerScissors()
                {
                    Name = "Jonny"
                };
    
                var winner = new Battle(player1, player2).PlayMatchUp();
    
                if (winner == null)
                {
                    Console.WriteLine("The Game was a draw.");
                }
                else
                {
                    Console.WriteLine("The Winner of this battle : {0}", winner.Name);
                }
    
                Console.ReadKey();
            }
    
        }
    
        public abstract class Player
        {
            public string Name { get; set; }
            public abstract GameAction Act();
        }
    
        public class PlayerRock : Player
        {
            public override GameAction Act()
            {
                return GameAction.Rock;
            }
        }
    
        public class PlayerPaper : Player
        {
            public override GameAction Act()
            {
                return GameAction.Paper;
            }
        }
    
        public class PlayerScissors : Player
        {
            public override GameAction Act()
            {
                return GameAction.Scissors;
            }
        }
    
        public enum GameAction
        {
            Rock,
            Paper,
            Scissors
        }
    
        public class Battle
        {
            private readonly Player _player1;
            private readonly Player _player2;
    
            public Battle(Player player1, Player player2)
            {
                this._player1 = player1;
                this._player2 = player2;
            }
    
            public  Player PlayMatchUp()
            {
    
                var result = WinningHand(_player1.Act(), _player2.Act());
    
                if (_player1.Act() == result)
                {
                    return _player1;
                }
    
                if (_player2.Act() == result)
                {
                    return _player2;
                }
    
                return null;
            }
            private  GameAction? WinningHand(GameAction p1, GameAction p2)
            {
                if (p1 == GameAction.Paper && p2 == GameAction.Rock)
                {
                    return GameAction.Paper;
                }
    
                if (p1 == GameAction.Paper && p2 == GameAction.Scissors)
                {
                    return GameAction.Scissors;
                }
    
                if (p1 == GameAction.Scissors && p2 == GameAction.Paper)
                {
                    return GameAction.Scissors;
                }
    
                if (p1 == GameAction.Scissors && p2 == GameAction.Rock)
                {
                    return GameAction.Rock;
                }
    
                if (p1 == GameAction.Rock && p2 == GameAction.Paper)
                {
                    return GameAction.Paper;
                }
    
                if (p1 == GameAction.Rock && p2 == GameAction.Scissors)
                {
                    return GameAction.Rock;
                }
    
                return null;
            }
    
    
        }
    }
