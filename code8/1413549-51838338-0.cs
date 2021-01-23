    public static void Main (string[] args)
    {
      var mediaPlayer = new MediaPlayer();
      mediaPlayer.MediaEnded += (sender, eventArgs) => Console.WriteLine ($"ended.");
      mediaPlayer.MediaOpened += (sender, eventArgs) => Console.WriteLine ($"started.");
      mediaPlayer.MediaFailed += (sender, eventArgs) => Console.WriteLine ($"failed: {eventArgs.ErrorException.Message}");
      mediaPlayer.Changed += (sender, eventArgs) => Console.WriteLine ("changed");
    
      mediaPlayer.Open (new Uri (@"S:\custom.mp3"));
      mediaPlayer.Play();
    
      Dispatcher.Run();
    }
