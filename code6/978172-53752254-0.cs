    Mapper.Initialize(cfg =>
    {
         cfg.ForAllMaps(SetMaxDepth);
    }
    private static void SetMaxDepth(TypeMap typeMap, IMappingExpression expression)
    {
         expression.MaxDepth(1);
    }
