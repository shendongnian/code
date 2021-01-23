    public class Rootobject
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public Library[] libraries { get; set; }
    }
      public class Library
      {
          public string name { get; set; }
      }
