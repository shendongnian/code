    var distinctDates = session.QueryOver<MyTable>()
        .Select(Projections.Distinct(
            Projections.SqlFunction("date", NHibernateUtil.Date,
                Projections.Property<MyTable>(mt => mt.DateCreated))))
        .List<DateTime>();
