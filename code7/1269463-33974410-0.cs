    var contacts = viewModel.Contacts.Select(c => new Contact
    {
        Title = c.Title,
        Forename = c.Forename,
        Surname = c.Surname,
        Phone = c.Phone,
        Email = c.Email
    }).ToList();  // <= ToList() added
