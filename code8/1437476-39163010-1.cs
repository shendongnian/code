    [HttpGet, Route("GetAll")]
    public IEnumerable<Customer> GetAllCustomers()
    {
        var allCustomers = repository.GetAll();
        // Set a breakpoint on the line below to confirm
        // you are getting data back from your repository.
        return allCustomers;
    }
