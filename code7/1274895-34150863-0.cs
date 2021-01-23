    // this assumes, that "RepresetativeEntityType" is a type name of representative entity
    IQueryable<RepresetativeEntityType> representatives = db.Represetatives;
    // pre-filter representatives, if CompanyID could be parsed
    int companyIdToFilter;
    if (int.TryParse(CompanyID, out companyIdToFilter))
    {
        representatives = representatives
            .Where(_ => _.CompanyId == companyIdToFilter);
    }
    return representatives
        .Select(_ => new Represetative
        {
           //REPRESETATIVES
           Id = _.Id,
           Name = _.Name,
           Email = _.Email,
           ContactNumber = _.ContactNumber,
           Quotes = _.Quotes,
           //COMPANY
           CompanyId = _.CompanyId
        })
        .ToList();
