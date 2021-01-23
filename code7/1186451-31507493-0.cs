    var query = session.QueryOver<ClientIdentifier>()
    if (clientId == null)
        query = query.WhereRestrictionOn(x => x.ClientId).IsNull;
    else
        query = query.Where(x => x.ClientId == clientId);
    var clientIdentifier =  query.JoinQueryOver(x => x.Region)
        .SingleOrDefault();
