    PersonListItemViewModel CreateViewModel(Person person)
    {
        return new PersonListItemViewModel
        {
            Name = person.Name,
            Country = person.Country,
            Email = person.User.Email,
        };
    }
