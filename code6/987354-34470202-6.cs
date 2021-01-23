        public List<Order> GetOrderPage(int page, int itemsPerPage, out int totalCount)
        {
            List<Order> orders = new List<Order>();
            using (DatabaseContext db = new DatabaseContext())
            {
                orders = (from o in db.Orders
                          orderby o.Date descending //use orderby, otherwise Skip will throw an error
                          select o)
                          .Skip(itemsPerPage * page).Take(itemsPerPage)
                          .ToList();
                totalCount = db.Orders.Count();//return the number of pages
            }
            return orders;//the query is now already executed, it is a subset of all the orders.
        }
