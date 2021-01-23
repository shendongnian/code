    public async Task<IHttpActionResult> Get(ODataQueryOptions<vwABC> options) 
		{ 
			if(options != null && options.SelectExpand != null)
			{
				options.Request.ODataProperties().SelectExpandClause = options.SelectExpand.SelectExpandClause; 
			}
			if(options != null && options.Count != null && options.Count.Value == true)
            {
                options.Request.ODataProperties().TotalCount = await base.GetCount("vwABC", options);
            }
			return await base.Get(options, "vwABC"); 
		} 
