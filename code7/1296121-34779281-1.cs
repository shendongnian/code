    // Player interface - the game engine will pass game state to the TakeTurn method
    // The target of the TakeTurn call can mutate the game state
    public interface IPlayer {
        void TakeTurn(GameState state);
        // Some info that other bots/players might need to look at
        int Chips { get; } 
        // also add other useful bits of info that other game components may need
        int SomeOtherUsefulInfo { get; }
    }
    public class GameState {
         
        // Is the game over?
        bool GameOver;
      
        // State information the bots/player will use to make decisions
        int ChipsInPot;
        // Reference to previous player which could help with AI decisions etc
        IPlayer previousPlayer;          
    }
    // Both Bot and Human class implement IPlayer which means they can both
    // be handled by the same game pipeline step but have radically different
    // implementations - such as AI or manual interaction
    public class Bot : IPlayer {
        // AI here making sure to implement the IPlayer interface
    }
    public class Human : IPlayer {
        // Human player handling code but with same interface
    }
    // Game engine simply runs a loop to keep passing turns
    public class GameEngine {
        GameState _state;
        List<IPlayer> _players;
        public GameEngine() {
           _players = new List<IPlayer>();
           _players.Add(new Bot("Fred"));
           _players.Add(new Bot("James"));
           _players.Add(new Bot("Arnold"));
           _players.Add(new Human("Jake")); 
        }
        public void GameLoop() {
            while(!_state.GameOver) {
              foreach(var player in _players) {
                  player.TakeTurn(_state); // etc - keep mutating state and looping until the game ends
 
                  // Add more complexity here :)
              }
            }
        }
    }
