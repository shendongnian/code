    public static IEnumerable<T> MyMethod<T>() where T : class 
    {
        List<T> resultList = new List<T>();   
        List<Customer> customers = new List<Customer>()
           {
                new Customer(), new Customer(), new Customer()
           };
        for(int i = 0; i < customer.Count; i++)
           resultList.Add(customers[i] as T);  // attempt to cast here
        return resultList;
    }
