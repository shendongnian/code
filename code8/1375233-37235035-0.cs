    async Task<List<Log>> GeLogs(int count, int pageSize, string search)
    {
    	var pages = Math.Ceiling(count / s);
    
    	var tasks = new Task<List<Log>>[(int)pages];
    	for (int i = 0; i < pages; i++)
    	{
    		var page = i;
    		tasks[i] = Task.Run(() =>
    		{
    			using (var c = new DbEntities())
    			{
    				c.Configuration.ProxyCreationEnabled = false;
    				c.Configuration.AutoDetectChangesEnabled = false;
    
    				var query = c.Logs.SqlQuery("SELECT * FROM Log WITH(NOLOCK) " + search + string.Format("ORDER BY LogTime DESC OFFSET (({0} - 1) * {1}) ROWS FETCH NEXT {1} ROWS ONLY", page + 1, (int)s));
    
    				return query.ToList();
    			}
    		});
    	}
    }
