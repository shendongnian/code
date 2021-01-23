    public List<CustomerSalesDto> Convert(List<Sale> sales, List<Customer> customers)
    {
        List<CustomerSalesDto> result = new List<CustomerSalesDto>();
        Dictionary<int, Customer> customer_dictionary = customers.ToDictionary(x => x.Id); //This is done to speed things up
        foreach (Sale sale in sales)
        {
            if(!customer_dictionary.ContainsKey(sale.CustomarId))
                throw new Exception("Could not find the customer");
            Customer customer = customer_dictionary[sale.CustomarId];
            result.Add(AutoMapper.Mapper.Map<CustomerSalesDto>(new Tuple<Sale, Customer>(sale , customer)));
        }
        return result;
    }
