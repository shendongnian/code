        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Employee).Include(o => o.MenuItems);
			var orderModels = new List<OrderViewModel>();
			foreach(var _order in orders)
			{
				OrderViewModel _orderViewModel = new OrderViewModel()
				{
					OrderId = _order.OrderId,
					Discount = _order.Discount,
					TableNum = _order.TableNum,
					EmpName = _order.Employee.EmpName
				};
				List<MenuItemViewModel> _menuItemViewModels = new List<MenuItemViewModel>();
				foreach (MenuItem menuItem in order.MenuItems)
				{
					if(_order.MenuItems.Contains(menuItem)) //where selected is true
					{
						_menuItemViewModel.Add(new MenuItemViewModel()
						{
							MenuId = menuItem.MenuId,
							ItemName = menuItem.ItemName,
							ItemPrice = menuItem.ItemPrice,
						});
					}
				}
				_orderViewModel.MenuItems = _menuItemViewModels;
				orderModels.Add(_orderViewModel);
			}
            return View(orderModels);
        } 
