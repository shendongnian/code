    static void ExecuteStoredProcedure()
    {
        Context context = new Context();
        QueryResult[] results = context.Database.SqlQuery<QueryResult>("dbo.GroupByUserAndDate").ToArray();
    }
    public class QueryResult
    {
        public int UserId { get; set; }
        public DateTime LogoutDate { get; set; }
        public int TimeSum { get; set; }
    }
