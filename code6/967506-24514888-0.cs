    User userEntity = null;
    var subQuery = QueryOver
        .Of<UserEmail>()
        .Where(ue => ue.UserGuid == userEntity.UserGuid)
        .ToRowCountQuery(); 
            
    var list = _session.StatefulSession
        .QueryOver<User>(() => userEntity)
        .SelectList(projections => projections
            .Select(x => x.UserGuid)
                 .WithAlias(() => userEntity.UserGuid)
            .Select(x => x.Address)
                 .WithAlias(() => userEntity.Address)
            // any property to be selected
            ... 
            // INLINE COUNT
            // our subquery placed into play
            .SelectSubQuery(subQuery)
                 // this will populate virtual/not mapped EmailCount
                 .WithAlias(() => userEntity.EmailCount) 
        )
        .TransformUsing(Transformers.AliasToBean<User>())
        //.Take(10).Skip(100) // paging
        .List();
