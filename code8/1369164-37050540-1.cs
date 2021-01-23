    public class Accounts { 
       public Accounts ()
       {
          Account = new List<string>();
       }
       public List<string> Account { get; set; }
    }
    public class Response {
       ...
       public Accounts Accounts { get; set; }
    }
