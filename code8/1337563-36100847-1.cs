    public override Addressbook Get(Expression<Func<Addressbook, bool>> predicate)
    {
        return base.Get(predicate,
                        x => x.Persons.Select(person => person.Title),
                        x => x.Persons.Select(person => person.Address.PostCode));
    }
