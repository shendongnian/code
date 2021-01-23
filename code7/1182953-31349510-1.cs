    public MyActionMethod(MyAction action)
    {
      switch (action)
      {
        case Music:
          MessageSong(songName);
          break;
        case Video:
          break;
      }
    }
    public void MessageSong(string songName)
    {
      switch(songName)
      {
        case "Song Name":
          messagebox.show("Playing Song Name");
          break;
    
        case "Song 2":
          messagebox.show("Playing Song 2");
          break;
      }
    }
    public enum MyAction
    {
      NoAction,
      Music,
      Video
    }
