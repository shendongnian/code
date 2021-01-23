       public class SupplierRepository
       {
            private MyContext _context;
            private Supplier _supplier;
    
            public SupplierRepository(int supplierId)
            {
                _context = new MyContext();
                _supplier = context.Suppliers.Single(x => x == supplierId);
            }
    
            // Retrieve the latest counter for a supplier
            public int GetCounter()
            {
                var counterEntity = _context.SupplierCounters.Single(x => x.SupplierId == _supplier.SupplierId);
                return counterEntity.OrderCountForSupplier;
            }
    
            // Increment the counter for the supplier
            public void IncrementCounter()
            {
                var counterEntity = _context.SupplierCounters.Single(x => x.SupplierId == _supplier.SupplierId);
                counterEntity.OrderCountForSupplier += 1;
                _context.SaveChanges();
            }
            // Adding a supplier
            public void AddSupplier(Order order)
            {
                int retries = 3;
    
                while (retries > 0)
                {
                    int currentCounter = GetCounter();
                    try
                    {
                        // Set the current counter into the order object
                        _order.OrderCountForSupplier = currentCounter;
                        _context.Add(order);
                        _context.SaveChanges();
                        // Success! update the counter (+1) and then break out of the while loop.
                        IncrementCounter();  
                        break;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Violating unique constraint
                        {
                            --retries;
                        }
                    }
                }
            }
        }
