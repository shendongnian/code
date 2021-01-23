        [Test]
        public void Test()
        {
    
            var plan = CreateQueryPlan("FROM User u JOIN u.Country c", false);
            //Check(plan.ReturnMetadata, false, true);
            foreach(var type in plan.ReturnMetadata.ReturnTypes)
            {
                Log.DebugFormat("name: {0}", type.Name);
            }
        }
    
        public IQueryPlan CreateQueryPlan(string hql, bool scalar)
        {
            var sessionFactory = (ISessionFactoryImplementor)SessionFactory.GetNHSessionFactory();
            var plan = sessionFactory.QueryPlanCache.GetHQLQueryPlan(hql, false,
                  new CollectionHelper.EmptyMapClass<string, IFilter>());
            return plan;
        }
