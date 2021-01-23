    public static class AudioManager
    {
        public const string BACKGROUND = "BACKGROUND.mp3";
    
        private static readonly MediaPlayer BackgroundSound = new MediaPlayer();
    
        public static void StartSoundManager()
        {
            BackgroundSound.Source = MediaSource.CreateFromUri(new Uri($"ms-appx:///Assets/Audio/{BACKGROUND}"));
    
            BackgroundSound.IsLoopingEnabled = true;
    
            ToggleSounds();
    
            BackgroundSound.Play();
        }
    
        public static void ToggleSounds()
        {
            BackgroundSound.IsMuted = !Settings.IsAudioOn; // IsAudioOn is false, still the sound plays
        }
    }
