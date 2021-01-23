    public class CustomerService : Service
    {
        public object Get(GetCustomers request)
        {
            return new GetCustomersResponse { Results = Db.Select<Customer>() };
        }
        public object Get(GetCustomer request)
        {
            return Db.SingleById<Customer>(request.Id);
        }
        public object Post(CreateCustomer request)
        {
            var customer = new Customer { Name = request.Name };
            Db.Save(customer);
            return customer;
        }
        public object Put(UpdateCustomer request)
        {
            var customer = Db.SingleById<Customer>(request.Id);
            if (customer == null)
                throw HttpError.NotFound("Customer '{0}' does not exist".Fmt(request.Id));
            customer.Name = request.Name;
            Db.Update(customer);
            return customer;
        }
        public void Delete(DeleteCustomer request)
        {
            Db.DeleteById<Customer>(request.Id);
        }
    }
