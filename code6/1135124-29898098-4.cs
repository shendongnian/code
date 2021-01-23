    public class CustomerDto : Customer { }
    public List<CustomerDto> Fetch(int categoryID)
    {
        return (from p in db.Products
                select new CustomerDto()
                {
                    CustomerId = r.CustomerId,
                    Name = r.Name,
                    Email = r.Email
                }).ToList();
    }
