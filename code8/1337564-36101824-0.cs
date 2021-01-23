    public class OrderController : Controller
    {
        private OrderService _orderService;
    
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }
    
        public ActionResult Search()
        {
            //do stuff here including calling _orderLogic.Search();
        }
    
        public ActionResult GetMyOrders()
        {
            //do stuff here including calling _orderLogic.GetMyOrders();
        }
    
        //more actions here
    }
