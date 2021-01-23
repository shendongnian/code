    string searchTerm = "Пупкин";
    using (MyDatabaseContext context = new MyDatabaseContext())
    {
        IEnumerable<Persons> p = context.Persons.Where(x => x.surname.Contains(searchTerm));
    }
