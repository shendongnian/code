 public class ExistingInitializer : ClearDatabaseSchemaIfModelChanges<ExistingContext>
    {
        protected override void Seed(ExistingContext context)
        {
            List<Order> orders = new List<Order>
            {
                new Order { OrderId = 10, Item = "Guitars", Quantity = 2, Id = Guid.NewGuid().ToString()},
                new Order { OrderId = 20, Item = "Drums", Quantity = 10, Id = Guid.NewGuid().ToString()},
                new Order { OrderId = 30, Item = "Tambourines", Quantity = 20, Id = Guid.NewGuid().ToString() }
            };
            List<Customer> customers = new List<Customer>
            {
                new Customer { CustomerId = 1, Name = "John", Orders = new Collection<Order> {
                    orders[0]}, Id = Guid.NewGuid().ToString()},
                new Customer { CustomerId = 2, Name = "Paul", Orders = new Collection<Order> {
                    orders[1]}, Id = Guid.NewGuid().ToString()},
                new Customer { CustomerId = 3, Name = "Ringo", Orders = new Collection<Order> {
                    orders[2]}, Id = Guid.NewGuid().ToString()},
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            base.Seed(context);
        }
    }
