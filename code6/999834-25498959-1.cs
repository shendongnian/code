    List<Foo> newList = employees.Select(m => new Foo
            {
                Name = m.Name,
                Bars = m.Bars.Where(u => u.IsActive == true).ToList()
            }).ToList();
    return newList;
