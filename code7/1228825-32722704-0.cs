    var egg = new Product { Name = "Eggs", Price = 2.0 };
    var bread = new Product { Name = "Bread", Price = 3.0 };
    var fooBars = new Product { Name = "FooBars", Price = 2.5 };
    var customerList = new List<Customer>
    {
        new Customer { Name = "Johny", City = "London", Orders = new List<Order>
        {
            new Order { Quantity = 3, Product = bread },
            new Order { Quantity = 1, Product = egg },
            new Order { Quantity = 2, Product = fooBars }
        }},
        new Customer { Name = "Morgan", City = "Copenhagen", Orders = new List<Order>
        {
            new Order { Quantity = 30, Product = bread }
        }},
        new Customer { Name = "Rasmus", City = "Amsterdam", Orders = new List<Order>
        {
            new Order { Quantity = 12, Product = fooBars }
        }}
    };
