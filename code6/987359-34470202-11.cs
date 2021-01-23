        public IEnumerable<OrderModel> GetOrderPage(int page, int itemsPerPage, string searchString, string sortOrder, int? partnerId,
            out int totalCount)
        {
            IQueryable<Order> query = DbContext.Orders; //get queryable from db
            .....//do your filtering, sorting, paging (do not use .ToList() yet)
            return queryOrders.SelectOrderModel().AsEnumerable();
            //or, if you want to include relations
            return queryOrders.Include(x => x.BillingAddress).AsEnumerable().SelectOrderModel();
            //notice difference, first AsEnumerable(), then SelectOrderModel(). Explanation below.
        }
