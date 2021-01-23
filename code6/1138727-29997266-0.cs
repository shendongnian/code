    // Get PropertyInfo from TEntity
    var entityIDProperty = entityType.GetProperty("ID");
   
    ...
    // Create an instantiation expression for SelectListDto
    var newExpression = Expression.New(typeof(SelectListDto));
    ...
    // Create a member initialization expression for TEntity's ID property
    var idBinding = Expression.Bind(entityIDProperty, idMemberExpression);
    ...
    // Try to instantiate an SelectDto with an initializer 
    // that initializes TEntity's ID property. This makes no sense!
    var memberInitExpression = Expression.MemberInit(newExpression, bindings);
