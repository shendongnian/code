    public int CharacterX
    {
      get
      {
        return Location.X;
      }
      set
      {
        Location = new Point(value, Location.Y);
      }
    }
