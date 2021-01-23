    customers= context.Customers.Where(c => c.IsEnabled
                                         && c.Contracts.Any(con => con.ContractEndDate >= DateTime.Today && con .ContractStartDate <= DateTime.Today)).ToList();
     foreach (Customer customer in customers)  
     {
        CustomerOverviewDto customerDto = GetCustomer(customer);
        Framework.Contract contract =
        customer.Contracts.Where(c => c.ContractEndDate >= DateTime.Today && c.ContractStartDate <= DateTime.Today)
            .First();
        SetContract(customerDto, contract);
     }
