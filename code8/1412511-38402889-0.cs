    var xy = tableQueryable
        .Where(!string.IsNullOrEmpty(cust.first_name) || ! string.IsNullOrEmpty(ust.lastName))
        .GroupBy(cust=> new { first_name = cust.first_name ?? string.Empty, last_name = cust.last_name ?? string.Empty})
        .Where(g=>g.Count()>1)
        .SelectMany(g => g.Select(cust => new {
            Id = cust.Id
        ,   cust.FirstName
        ,   cust.LastName
        ,   cust.RepId
        }));
