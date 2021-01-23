    public struct MyTimeSpan
    {
      private readonly TimeSpan _data;
      public MyTimeSpan(TimeSpan data)
      {
        _data = data;
      }
      public override string ToString()
      {
        return string.Format("{0:f0}min {1}sec", _data.TotalMinutes, _data.Seconds);
      }
    }
