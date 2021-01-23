    public class OrdersController : ODataController
    {
                          
        [EnableQuery(PageSize = 100)]
        public IQueryable<OrderDto> Get(ODataQueryOptions<OrderDto> queryOptions, string company)
        {
            var erpService = ErpServiceFactory.GetService(company);
            return erpService.Orders(queryOptions);
        }
        ...
        // Post
        // Patch/Put
        // Delete
    }
