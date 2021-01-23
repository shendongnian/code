    // Filter by global configuration
    QueryFilterManager.Filter<Customer>(q => q.Where(x => x.IsActive));
    var ctx = new EntitiesContext();
    // TIP: You can also add this line in EntitiesContext constructor instead
    QueryFilterManager.InitilizeGlobalFilter(ctx);
    
    // Filter by instance configuration
    var ctx = new EntitiesContext();
    ctx.Filter<Post>(MyEnum.EnumValue, q => q.Where(x => !x.IsSoftDeleted)).Disable();
