    var db = new DAL.MyEntities();
    var type = db.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                           .Where(pr => pr.PropertyType.IsGenericType)
                           .Where(pr => pr.PropertyType.GetGenericTypeDefinition() ==  
                                               typeof(DbSet<>))
                           .Select(pr => pr.PropertyType.GetGenericArguments().Single())
                           .SingleOrDefault(t => t.Name == MyClassName);
    if (type == null) / * type not found case */ ;
    
    var names = type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(property => property.Name)
                    .ToArray();
                                          
