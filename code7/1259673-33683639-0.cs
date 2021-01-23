    [Webmethod]
    public static virtual bool LookIfCustomerExist(string name)
        {
            List<Customer> customers = SearchClient(name);
            bool returnedValue = customers.Count != 0;
            return returnedValue;
        }
