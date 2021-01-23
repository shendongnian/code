    public class Channel
    {
      private _listings = new List<SpotsList>();
      
      public IList<SpotsList> SpotsList { get { return _listings; } }
    }
    public class SpotsList
    {
      public DateTime Date { get; set; }
      public double Val1 { get; set; }
      public double Val2 { get; set; }
      public double Val3 { get; set; }
      public double Val4 { get; set; }
    }
