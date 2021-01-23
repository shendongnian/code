    namespace V1.test.RPG
    {
        public class GameOptions
        {
            public GameOptions()
            {
                 FullScreen = false;
                 DifficultyLevel = Difficulty.Normal;
                 SoundSetting = Sound.On;
                 // And so on.
            }
    
            public Boolean FullScreen { get; set; }
            public Difficulty DifficultyLevel { get; set; }
            public Sound SoundSetting { get; set; }
            //And so on...
        }
    
        public enum Difficulty 
        {
            EASY,
            MEDIUM,
            HARD
        }
    
        public enum Sound 
        {
            ON,
            QUIET,
            OFF
        }
    
        public enum Music
        {
            ON,
            QUIET,
            OFF
        }
    
        public enum ResolutionWidth
        {
            SMALL = 1280,
            MEDIUM = 1366,
            LARGE = 1920,
            WIDESCREEN = 2560
        }
    
        public enum ResolutionHeight
        {
            SMALL = 800,
            MEDIUM = 768,
            LARGE = 1080,
            WIDESCREEN = 1080
        }
    
    }
