    session = NHibernateSessionManager.Instance.GetSession();
    ICriteria criteria = session.CreateCriteria(typeof(Alarms));
    criteria.CreateCriteria("Reading").CreateCriteria("Truck")
            .Add(Expression.Eq("Company.CompanyId", companyId));
    alarmsList = criteria.List<Alarms>();
