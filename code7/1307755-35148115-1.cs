    var db = new DAL.MyEntities();
    var type = db.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                           .Where(pr => pr.PropertyType.IsGenericType)
                           .Where(pr => pr.PropertyType.GetGenericTypeDefinition() ==  
                                               typeof(DbSet<>))
                           .Where(pr => pr.GetGenericArguments()
                                          .Single()
                                          .Name == MyClassName)
                           .SingleOrDefault();
    if (type == null) / * type not found case */ ;
    
    var names = type.GetProperties()
                    .Select(property => property.Name)
                    .ToArray();
                                          
