    var cusRelationships = SvcClient.Client.Context.CusRelationships
        .Where(c =>
                   c.CustomerId == identity.rCustomerId &&
                   c.AddedOn.HasValue &&
                   c.AddedOn.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
        .Select(c => c)
        .ToList();
