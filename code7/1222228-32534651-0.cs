    public class Game
    {
        [Display(Name = "Select you guess")]
        [Required]
        public string UsersGuess { get; set; }
        public string ComputersGuess { get; set; }
        public string Winner { get; set; }
        public List<string> Options { get { return new List<string>() { "Rock", "Paper", "Scissors" }; }
        public void Play()
        {
          var random = new Random().Next(Options .Count);
          ComputersGuess = Options[random];
          Winner = // your logic here
        }
    }
