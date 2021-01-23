    var products = genericRepository<Product>.GetOrdersAndCustomersByCustomerId(...);
    // your method
    public Customer GetOrdersAndCustomersByCustomerId(string id)
    {
        var customer = this.db.SingleOrDefault<T>("WHERE CustomerId =    @0", id);
        var orders = this.db.Query<Order>("WHERE CustomerId = @0", id).ToList();
        if (customer != null && orders != null)
        {
            // what now? customer is of type product.
            customer.Orders = new List<Order>();
            customer.Orders.AddRange(orders);
        }
        return customer;
    }
