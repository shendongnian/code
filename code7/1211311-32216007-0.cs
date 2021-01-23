        public static List<Customer> GetCustomersWithOrderItemQuantity(List<Customer> customers, int quantity)
        {
            var customers2 = customers.TakeWhile(c => c.Orders.Any(o => o.OrderItems.Any(oi => oi.Quantity == quantity))).ToList();
            customers2.ForEach(cust => cust.Orders.ForEach(o => o.OrderItems.RemoveAll(oi => oi.Quantity != quantity)));
            return customers2;
        }
