    if (criteria.Domains != null && criteria.Domains.Any())
    {
        domainTableTypes = criteria.Domains.Select(d => new DomainTableType(d));
    }
    else 
    {
        domainTableTypes = Enumerable.Empty<DomainTableType>();
    } 
