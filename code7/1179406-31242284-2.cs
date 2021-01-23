    public static IEnumerable<T> MyMethod<T>() where T : class 
    {
        List<Customer> customers = new List<Customer>()
        List<T> resultList = new List<T>();   
           {
                new Customer(), new Customer(), new Customer()
           };
        for(int i = 0; i < customer.Count; i++)
           resultList.Add(customers[i] as T);  // attempt to cast here
        return resultList;
    }
