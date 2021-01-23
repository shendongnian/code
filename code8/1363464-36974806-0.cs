    var session = _sessionLocator.For(typeof (UserPartRecord));
    const string fromTables =
        "FROM Orchard.ContentManagement.Records.ContentItemVersionRecord ItemVersion"
        + " JOIN ItemVersion.ContentItemRecord Item"
        + " JOIN Item.UserPartRecord User"
        + " WHERE ItemVersion.Published = true"
        + " AND User.UserName IS NOT NULL";
    const whereClause =
        "User.Id NOT IN (SELECT Role.UserId FROM Orchard.Roles.Models.UserRolesPartRecord Role)";
    const orderBy = "ORDER BY User.UserName";
    var pageQuery = session.CreateQuery(
        "SELECT DISTINCT User.Id, User.UserName "
        + fromTables
        + " AND " + whereClause
        + " " + orderBy)
        .SetFirstResult(pager.GetStartIndex())
        .SetMaxResults(takeNum);
    var ids = pageQuery.List<int>();
    var results = contentManager
        .GetMany<UserPart>(ids, VersionOptions.AllVersions, QueryHints.Empty);
