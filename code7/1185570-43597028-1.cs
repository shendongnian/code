    var interceptor = new ProgressInterceptor(progress);
    var session = sessionFactory.OpenSession(interceptor);
    var query = session.Query<Entity>()...
    interceptor.StartIntercept<Entity>(0, 100, query.Count());
    entities = query.Fetch(x => x.Chidren).ToList();
    interceptor.StopIntercept();
