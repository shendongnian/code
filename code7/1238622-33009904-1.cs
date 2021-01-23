    var itemsQuery = DB_Context.Employees.Where(%%%%% WHATEVER %%%%);
    if (takeMax.Value > 0)
    {
      itemsQuery  = itemsQuery.Take(takeMax);
    }
    
    var items = itemsQuery.ToList();
