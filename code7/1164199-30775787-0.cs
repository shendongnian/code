    TransactionEntitytrans = null;
    TransactionDetails details = null;
    var results = session.QueryOver<TransactionEntity>(() => trans)
        .JoinQueryOver(() => trans.Details, () => details, JoinType.InnerJoin
            , Restrictions.EqProperty(
                Projections.Property<TransactionEntity>(_ => trans.DatePerformed ),
                Projections.Cast(
                  NHibernate.NHibernateUtil.Date, 
                  Projections.Property<Occupation>(_ => details.datetimedetails ))
                )
        )
        .List<TransactionEntity>();
