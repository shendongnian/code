    public void Run()
    {
      while (! token.IsCancellationRequested)
      {
        PlayMusicSlice();
      }
    }
