    namespace Subscriber
    {
      public class SubscribeClassCreatedByMe 
      {
        public string email_address { get; set; }
        public string status { get; set; }
        public MergeFieldClassCreatedByMe merge_fields { get; set; }
      }
    }
    namespace Subscriber
    {
      public class MergeFieldClassCreatedByMe
      {
        public string FNAME { get; set; }
        public string LNAME { get; set; }
      }
    }
