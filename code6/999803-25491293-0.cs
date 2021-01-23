    var people = personDTOs.GroupBy(i => i.PersonId).Select(
        // Each PersonId group projects a single Person object.
        i => new Person() {
            PersonId = i.Key,
            // Assuming that all names in this group are the same.
            Name = i.First().Name,
            // The elements in the group are used to project Order objects.
            orders = i.Select(o => new Order() {
                OrderId = o.OrderId,
                OrderName = o.OrderName,
                OrderType = o.OrderType
            }).ToList()
        }).ToList();
