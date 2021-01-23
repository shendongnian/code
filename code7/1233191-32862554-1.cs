    public class RequiresOrderServiceAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string salesCompany = "";
            var data = actionContext.Request.GetRouteData();
            if (data.Values.ContainsKey("company"))
            {
                salesCompany = data.Values["company"].ToString();
                var orderService = ErpServiceFactory.GetService(company);
                actionContext.ActionArguments.Add("erpService", orderService);
            }
        }
    }
    public class OrdersController : ODataController
    {
                          
        [EnableQuery(PageSize = 100)]
        public IQueryable<OrderDto> Get(ODataQueryOptions<OrderDto> queryOptions, IOrderService erpService)
        {
            return erpService.Orders(queryOptions);
        }
        ...
        // Post
        // Patch/Put
        // Delete
    }
