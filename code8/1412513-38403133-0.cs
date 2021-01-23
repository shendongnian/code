    var duplicates = tableQueryable
        .Where(c => !string.IsNullOrWhiteSpace(c.first_name) || !string.IsNullOrWhiteSpace(c.last_name))
        .GroupBy(c => new { FirstName = c.first_name ?? "", LastName = c.last_name ?? "" })
        .Where(group => group.Count() > 1) // Only keep groups with more than one item
        .SelectMany(g => g) // Flatten out groups into a single collection
        .Select(c => new {c.first_name, c.last_name, c.customer_rep_id});
