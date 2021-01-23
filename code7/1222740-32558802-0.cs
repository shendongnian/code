       var qctx = new TQueryContext
       {
          QueryType = filter == null ? CommonQueryType.FillAll : CommonQueryType.FillWhere,
          Filter2 = filter.ToExpressionNode(),
          OrderBy = orderBy
       };
