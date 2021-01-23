    var query = dm.Order;
    if(!string.IsNullOrEmpty(filter)){
        query = query.Where(o => o.Customer.Name.ToLower().Contains(filter) 
                               ||o.Customer.Surname.ToLower().Contains(filter));
    }    
    var result = query.Select(o => new {...}).ToList();
