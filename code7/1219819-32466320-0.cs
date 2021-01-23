    public static List<Customer> FromModelToEntity(List<CustomerModel> modelList)
    {
        List<Customer> entityList = new List<Customer>();
        foreach (var item in modelList)
        {
          entityList.Add(CustomerModel.FromModelToEntity(item));
        }
        return entityList;
    }
