    public static class HighScoreManager
    {
        public static int HighScore { get; private set; }
    
        public static void UpdateHighScore(int value)
    	{
        	HighScore = value;
        }
    }
