        public PageResult<Orders> GetOrdersPage(ODataQueryOptions<Orders> queryOptions)
        {
		        // Parse queryOptions to get Top and Skip
                var top = queryOptions.Top.RawValue;
                var skip = queryOptions.Skip.RawValue;
		        //Call the dataaccess method and then get Querable result
                var queryResults = dataAccess.GetOrders(top,skip).AsQuerable<Orders>();
		        //Return Page result 
                return new PageResult<Orders>(queryResults, new URI("Next page URI"), 1234); //1234 - is total count of records in table
	}              
