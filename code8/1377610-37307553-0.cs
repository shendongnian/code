    if (AllCustomers.Any(x => x.id == pNewCustomer.id))
    {
        // already exists. Do not add
    }
    else
    {
        AllCustomers.Add(pNewCustomer);
    }
