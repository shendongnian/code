    Item rItem = null;
    var query = Session.QueryOver<Item>(() => rItem);
    ...
    query = query.Select(Projections.Sum(
            Projections.SqlFunction(new VarArgsSQLFunction("(", "*", ")"),
            NHibernateUtil.Double,
            Projections.Property(() => rItem.Ammount),
            Projections.Property(() => rItem.Wight))));
