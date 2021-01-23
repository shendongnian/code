    [WebMethod]
    public Customer MyMethod(int id)
    {
        Model model = new Model();
        Customer customer = new Customer();
    
        try
        {
            customer = model.Customer.Where(x => x.Name == id).First();
        }
        catch (Exception ex)
        {
            throw new System.NullReferenceException(ex.Message, ex.InnerException);
        }
        return customer;
    }
