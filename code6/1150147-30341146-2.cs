    public class AllData
    {
       public TimeSpan diff { get; set; }
       public string myEvent {get;set;}
    }
    public class RootObject
    {
      public List<AllData> dataFromDb { get; set; }
      //all your other code
    }
