    IList<CustomField> originalList = ticketService.GetCustomFields();
    IList<CustomField> newList = originalList
        .Select(x => new CustomField
        {
            Id = x.Id,
            Name = x.Name,
            Value = x.Value
        })
        .ToList();
