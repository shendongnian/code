    public class ApplicationsQueryBuilder
    {
        private static readonly IProjection ApplicationTypeProperty = Projections.Property<Application>(a => a.ApplicationType);
        private readonly DetachedCriteria _query = DetachedCriteria.For<Application>();
        private bool _withProperties;
        public ApplicationsQueryBuilder WithType(ApplicationType type)
        {
            _query.Add(Restrictions.Eq(ApplicationTypeProperty, type));
            return this;
        }
        public ApplicationsQueryBuilder WithTypes(params ApplicationType[] types)
        {
            var or = Restrictions.Disjunction();
            foreach (var type in types)
            {
	            or.Add(Restrictions.Eq(ApplicationTypeProperty, type));
            }
            
            _query.Add(or);
            return this;
        }
        public ApplicationsQueryBuilder WithProperties()
        {
            _withProperties = true;
            return this;
        }
        ...
        public ICriteria Create(ISession session)
        {
            if (_withProperties)
            {
                _query.SetProjection(Projections.Id());
                return session.CreateCriteria<Application>()
                    .Add(Subqueries.PropertyIn("Id", _query));
            }
            else
            {
                return _query.GetExecutableCriteria(session);
            }
        }
    }
