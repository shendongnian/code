    var subquery = QueryOver.Of<Quarantine>()
        .Select(x => x.QuarantinePerson.Id);
    var naturalPersons = Session.QueryOver<NaturalPerson>()
        .WithSubquery.WhereProperty(x => x.Id).NotIn(subquery)
        //.Where(x => x.NaturalProperty == somehing)
        .Future();
    var legalPersons = Session.QueryOver<LegalPerson>()
        .WithSubquery.WhereProperty(x => x.Id).NotIn(subquery)
        //.Where(x => x.LegalProperty == somehing)
        .Future();
    var persons = naturalPersons.Cast<Person>().Union(legalPersons);
