    private ExpressionWithCounter<GenericEntity> GetGenericEntitySearchExpression(GenericEntityParameter searchParameter)
    {
        var expressionCounter = new ExpressionWithCounter<GenericEntity>();
        expressionCounter.Predicate = PredicateBuilder.True<GenericEntity>();
	
        if (searchParameter.RegionCode == 1)
        {
        expressionCounter.Append(expressionCounter.Predicate.And<GenericEntity>(e => e.RegionCode == searchParameter.RegionCode));
        }
        if (searchParameter.CountryCode > 0)
        {
            expressionCounter.Append(expressionCounter.Predicate.And<GenericEntity>(e => e.CountryCode == searchParameter.CountryCode));
        }
    }
    public class ExpressionWithCounter<T>
    {
        public Expression<Func<T, bool>> Predicate;
        public int Count { get; private set; }
        public void Append(Expression<Func<T, bool>> expression)
        {
            Predicate = expression;
            Count++;
        }
    }
    ExpressionWithCounter<GenericEntity> whereExperssion = GetGenericEntitySearchExpression(searchParameter);
    //Is Any expression added?
    if(whereExperssion.Count > 0)
    {
        //Perform any action
    }
