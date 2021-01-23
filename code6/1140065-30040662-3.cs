    var childIds = children.Select(c => c.Id).ToArray();
    Parent parent = null;
    Child child = null;
    return Session
        .QueryOver.Of<Child>(() => child)
        .WhereRestrictionOn(x => x.Id).IsIn(childIds)
        .JoinQueryOver(x => x.Parents, () => parent)
        .Where(Restrictions.Eq(Projections.Count(() => parent.Id), childIds.Length))
        .Select(Projections.Group(() => parent.Id));
