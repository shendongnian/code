    public class ApplicationsQuery
    {
        private static readonly IProjection ApplicationTypeProperty = Projections.Property<Application>(a => a.ApplicationType);
        private readonly ISession _session;
        private readonly DetachedCriteria _query;
        private bool _withProperties;
        public ApplicationsQuery(ISession session)
        {
            _session = session;
            _query = DetachedCriteria.For<Application>();
        }
        public ApplicationsQuery WithType(ApplicationType type)
        {
            _query.Add(Restrictions.Eq(ApplicationTypeProperty, type));
            return this;
        }
        public ApplicationsQuery WithTypes(params ApplicationType[] types)
        {
            var or = Restrictions.Disjunction();
            foreach (var type in types)
            {
	            or.Add(Restrictions.Eq(ApplicationTypeProperty, type));
            }
            
            _query.Add(or);
            return this;
        }
        public ApplicationsQuery WithProperties()
        {
            _withProperties = true;
            return this;
        }
        ...
        public IList<Application> Run(int skip = 0, int take = 100)
        {
            ICriteria executableQuery;
            if (_withProperties)
            {
                _query.SetProjection(Projections.Id());
                executableQuery = _session.CreateCriteria<Application>()
                    .Add(Subqueries.PropertyIn("Id", _query));
            }
            else
            {
                executableQuery = _query.GetExecutableCriteria(_session);
            }
            return executableQuery
                .SetFirstResult(skip)
                .SetMaxResults(take)
                .List<Application>();
        }
    }
