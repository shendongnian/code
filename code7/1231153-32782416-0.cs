    public class DataPoint
    {
      public DataPoint(string uid)
      {
        UniqueId = uid;
      }
    public string UniqueId {get; private set; }
    public string ScannerID { get; set; }
    public DateTime ScanDate { get; set; }
}
