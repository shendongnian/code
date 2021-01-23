    namespace MyApp.ViewModels
    {
        public class OrderViewModel
        {
            public int OrderId { get; set; }
            public int ProductId { get; set; }
            public int Discount { get; set; }
        }
    }
    public ActionResult Index()
    {
        NorthWindEntities db = new NorthWindEntities();
        
        List<OrderViewModel> data = (from id in db.Orders
                                    join ordid in db.Order_Details on id.OrderID equals ordid.OrderID
                                    select new OrderViewModel()
                                    {
                                        OrderId = id.OrderID,
                                        ProductId = ordid.ProductID,
                                        Discount = ordid.Discount
                                    }).ToList();
        
        ViewData["Data"] = data;
        return View();
