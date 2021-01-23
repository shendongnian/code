    public class MyLab_ClientRef
    {
        public int UserId { get; set; }
        public string ClientId { get; set; }
        // ... more fields ...
    
        public static MyLab_ClientRef GetUser(OracleConnection conn, int UserId, string ClientId)
        {
            bool Ok = false;
    		
            var QueryResultRecords =
                conn.Query<MyLab_ClientRef>(@"SELECT * FROM MyLab_ClientRef WHERE UserId = :UserId AND ClientId = :ClientId",new { UserId = UserId, ClientId = ClientId });
    		
    			if(QueryResultRecords.Any())
    				return QueryResultRecords.First();
    			else
    			    return null;		
            
        }  
    }
