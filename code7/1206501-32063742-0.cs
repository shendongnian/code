    foreach (var customer in collListItem.Select(
                item => 
                    new {
                        Persona = item["Persona"].ToString(),
                        CustomerName = item["Title"].ToString()
                    }).Distinct()
                    .Select(r => new Customer { Persona = r.Persona,
                                                CustomerName = r.CustomerName }))
    {
        customers.Add(customer);
    }
