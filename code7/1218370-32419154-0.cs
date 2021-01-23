    class Score
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public Score(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
