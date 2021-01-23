    // Initialize background music
    songURL = new NSUrl("Sounds/"+filename);
    NSError err;
    backgroundMusic = new AVAudioPlayer (songURL, "wav", out err);
    backgroundMusic.Volume = MusicVolume;
    backgroundMusic.FinishedPlaying += delegate { 
        backgroundMusic = null;
    };
    backgroundMusic.NumberOfLoops=-1;
    backgroundMusic.Play();
    backgroundSong=filename;
