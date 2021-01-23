    public class CustomerServices : Service
    {
        public void Any(DeleteCustomer request)
        {
            if (request.Id <= 0)
                throw new ArgumentException("Id Required", "Id")
    
            Db.DeleteById<Customer>(request.Id);
        }
    }
