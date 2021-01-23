    Expression.Like(
        // Projections.Cast( NHibernateUtil.String,
        Projections.Cast( NHibernateUtil.AnsiString,
        Projections.Property<ErrorSummaryEntity>(x => x.Quantity)),
            searchValue, MatchMode.Anywhere)
