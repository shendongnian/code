    public class Customer_ByName : AbstractIndexCreationTask<Customer>
    {
        public Customer_ByName()
        {
            Map = customers => from customer in customers
                                select new
                                {
                                    Name = customer.Name,
                                    DocumentId = MetadataFor(customer)["__document_id"]
                                };
        }
    }
