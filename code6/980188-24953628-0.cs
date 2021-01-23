    public class GetUserStatisticsQuery 
    {
        public int UserId { get; set; }
    }
    
    public class GetUserStatisticsQueryResult
    {
        ...
    }
    public class GetUserStatisticsQueryHandler : 
        IHandleQuery<GetUserStatisticsQuery, GetUserStatisticsQueryResult> 
    {
        public GetUserStatisticsQueryResult Handle(GetUserStatisticsQuery query) 
        {
            ... "SELECT * FROM x" ...
        }
    }
    
    var result = _queryExecutor.Execute<GetUserStatisticsQueryResult>(
        new GetUserStatisticsQuery(1));
