    public class MyResult
    {
      public string User {get;set;}
      public DateTime? Date {get;set;}
      public int Count {get;set;}
    }
    var grouped = db.ExecuteQuery<MyResult>(@"select [User], 
      Cast([Date] as Date) as [Date],
      Count(*) as [Count]
    from myTable
    group by [user], Cast([Date] as Date)");
