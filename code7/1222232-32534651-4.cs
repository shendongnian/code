    public class Game
    {
        public Game()
        {
          Options = new List<string>(){ "Rock", "Paper", "Scissors" };
        }
        [Display(Name = "Select you guess")]
        [Required]
        public string UsersGuess { get; set; }
        public string ComputersGuess { get; set; }
        public string Winner { get; set; }
        public List<string> Options { get; private set; }
        public void Play()
        {
          var random = new Random().Next(Options .Count);
          ComputersGuess = Options[random];
          Winner = // your logic here (compare UserGuess and ComputerGuess)
        }
    }
