    int num = 0;
    MethodInfo genericMethod = session.GetType().GetMethod("Query");
    foreach (var item in list)
    {   
        MethodInfo specificMethod = genericMethod.MakeGenericMethod(item);
        IQueryable result = (IQueryable)method.Invoke(session, new object[0]);
        num += result.Count();
    }
