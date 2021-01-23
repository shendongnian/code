    List<PersonDTO> list = new List<PersonDTO>();
    List<Person> personList = list.GroupBy(r => r.PersonId)
        .Select(grp => new Person()
        {
            PersonId = grp.Key,
            Name = grp.First().Name,
            orders = grp.Select(r => new Order()
            {
                OrderId = r.OrderId,
                OrderName = r.OrderName,
                OrderType = r.OrderType
            }).ToList()
        }).ToList();
