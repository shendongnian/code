    public class Slide
    {
      private Optional<double> _runningTime;
      private Optional<string> _title;
      private Optional<int> _id;
      public double runningTime
      {
        get { return _runningTime.GetValueOrDefault(); }
        set { _runningTime = new Optional<double>(value); }
      }
      public string title
      {
        get { return _title.GetValueOrDefault(); }
        set { _title = new Optional<string>(value); }
      }
      public int id
      {
        get { return _id.GetValueOrDefault(); }
        set { _id = new Optional<int>(value);
      }
    }
