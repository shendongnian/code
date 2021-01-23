        public ActionResult Index(int? page)
        {
            int pagenumber = (page ?? 1) -1; //I know what you're thinking, don't put it on 0 :)
            OrderManagement orderMan = new OrderManagement(HttpContext.ApplicationInstance.Context);
            int totalCount = 0;
            List<Order> orders = orderMan.GetOrderPage(pagenumber, 5, out totalCount);
            List<OrderViewModel> orderViews = new List<OrderViewModel>();
            foreach(Order order in orders)//convert your models to some view models.
            {
                orderViews.Add(orderMan.GenerateOrderViewModel(order));
            }
            //create staticPageList, defining your viewModel, current page, page size and total number of pages.
            IPagedList<OrderViewModel> pageOrders = new StaticPagedList<OrderViewModel>(orderViews, pagenumber + 1, 5, totalCount);
            return View(pageOrders);
        }
