    public static string GetJson() 
    {
      var person = new Person();
      person.FirstName = "John";
      person.LastName = "Doe";
      person.Orders = new List<Order>();
      person.Orders.Add(new Order() { Id=1, Description="..." });
      return JsonConvert.SerializeObject(person);
    }
