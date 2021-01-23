    public class MyTestClass
    {
        private int _gamesPlayed;
        private int _gamesLost;
        public int NumberOfWins { get { return _gamesPlayed - _gamesLost; } } 
    }
