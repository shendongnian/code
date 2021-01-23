    class UpdateMethod<T>
    {
        
        updatemethod<T>(List<T> UpdatedCustomerList, List<T> extistingCustomerList)
        {
            var _context = new YourDbContex() // You db context
            foreach (var item in UpdatedCustomerList)
            {
                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
