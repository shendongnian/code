    namespace App
    {
      public class Event
      {
          public Type type { get; set; }
          public Details details { get; set; }
      }
      public class Details
      {
          public string timestamp { get; set; }
          public string reference { get; set; }
      }
      public class SendDetails : Details
      {
          public string id { get; set; }
          public string correlator { get; set; }
          public string device1 { get; set; }
          public string device2 { get; set; }
          public string device3 { get; set; }
      }
      public class ReceiveDetails : Details
      {
          public string primaryid { get; set; }
          public string primary_correlator { get; set; }
          public string secondaryid { get; set; }
          public string secondary_correlator { get; set; }
          public string device4 { get; set; }
          public string device5 { get; set; }
      }
      class ReceiveEvent : Event
      {
        public ReceiveEvent()
        {
           this.type = Type.Recieve;
           this.Details = new ReceiveDetails();
        }
      }
      class SendEvent : Event
      {
         public SendEvent()
         {
            this.type = Type.Send;
            this.Details = new SendDetails();
         }
      }
      public enum Type
      {
         Send,
         Receive
      }
    }
