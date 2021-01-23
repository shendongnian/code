    public class UserActivity
    {
      public string UserEmail { get; set; }
      public string SQL_Query { get; set; }
      public string Query_Start { get; set; }
      public string Query_End { get; set; }
      public string Query_Time { get; set; }
    }
    static void Main(string[] args)
    {
      UserActivity log = new UserActivity();
      DateTime start = DateTime.Now - TimeSpan.FromMinutes(2);
      DateTime end = DateTime.Now;
      TimeSpan Duration = end - start;
      log.UserEmail = "email@here.gov";
      log.SQL_Query = "exec FTSP_FTProblemsByCategory 5";
      log.Query_Start = String.Format("{0:hh:mm:ss}", start);
      log.Query_End = String.Format("{0:hh:mm:ss}", end);
      log.Query_Time = String.Format("{0:mm:ss.ff}", Duration.ToString());
    }
