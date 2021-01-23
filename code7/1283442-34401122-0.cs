    Expression<Func<TObject, bool>> GetDatePeriodOverlapExpression<TObject>(Expression<Func<TObject, DateTime>> StartDate, Expression<Func<TObject, DateTime>> EndDate, DateTime filterStartDate, DateTime filterEndDate)
    {
        var parameter = Expression.Parameter(typeof(TObject));
    
        var startDate = ParameterRebinder.ReplaceParameters(parameter, StartDate.Body);
        var endDate = ParameterRebinder.ReplaceParameters(parameter, EndDate.Body);
        var filterStartDateExp = Expression.Constant(filterStartDate);
        var filterEndDateExp = Expression.Constant(filterEndDate);
        
    
        var e1 = Expression.GreaterThanOrEqual(startDate, filterStartDateExp); // StartDate(x) >= filterStartDate
        var e2 = Expression.LessThanOrEqual(startDate, filterEndDateExp); // StartDate(x) <= filterEndDate
    
        var e3 = Expression.AndAlso(e1, e2); // (StartDate(x) >= filterStartDate && StartDate(x) <= filterEndDate)
    
        var e4 = Expression.GreaterThanOrEqual(endDate, filterEndDateExp); // EndDate(x) <= filterEndDate
        var e5 = Expression.LessThanOrEqual(endDate, filterStartDateExp); // EndDate(x) >= filterStartDate
    
        var e6 = Expression.AndAlso(e4, e5); // (EndDate(x) <= filterEndDate && EndDate(x) >= filterStartDate)
    
        var e7 = Expression.GreaterThanOrEqual(startDate, filterStartDateExp); // StartDate(x) <= filterStartDate
        var e8 = Expression.LessThanOrEqual(endDate, filterEndDateExp); // EndDate(x) >= filterEndDate
    
        var e9 = Expression.AndAlso(e7, e8); // (StartDate(x) <= filterStartDate && EndDate(x) >= filterEndDate)
    
        var e10 = Expression.OrElse(Expression.OrElse(e3, e6), e9);
    
        return Expression.Lambda<Func<TObject, bool>>(e10, parameter);
    }  
    
    public class ParameterRebinder : ExpressionVisitor 
    { 
        private readonly ParameterExpression parameter; 
    
    
        public ParameterRebinder(ParameterExpression parameter) 
        { 
            this.parameter = parameter; 
        } 
    
        public static Expression ReplaceParameters(ParameterExpression parameter, Expression exp) 
        { 
            return new ParameterRebinder(parameter).Visit(exp); 
        } 
    
        protected override Expression VisitParameter(ParameterExpression p) 
        { 
            return base.VisitParameter(parameter); 
        } 
    }
 
