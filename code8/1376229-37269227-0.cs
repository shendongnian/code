            [Authorize]
            public ActionResult Index(Int32? days)
            {
                string currentUser = this.User.Identity.GetUserName();
                var orders = db.Orders  //assume db is something inherited from DbContext
                    .Where(o => o.UserName == currentUser)
                    .OrderByDescending(o => o.OrderDate);
                if (days.HasValue)
                {
                    var startingDate = DateTime.Now.AddDays((-1) * days.Value);
                    orders = orders.Where(o => o.OrderDate >= startingDate);
                }
    
                var orderList = orders.ToList();
    
                var returnOrderIds = db.ReturnDetails.Select(detail => detail.OrderId).ToList();
    
                //here you will need to check with business analyst staff what is the rule for 'returnstats'.
                //The business logic here is that if there is at least one order whose OrderId is in the ReturnDetails
                //the 'returnstats' is 'Returning Item' otherwise it's 'Processing'.
                if (orderList.Any(o => returnOrderIds.Contains(o.OrderId))
                {
                    ViewBag.returnstats = "Returning Item";
                } else
                {
                    ViewBag.returnstats = "processing";
                }
    
                var viewModels = ...//the source code to create Order ViewModel with variable orderList
                return View(viewModels);
            }
