    protected override Expression VisitLambda<T>(Expression<T> node)
    {
        var parameters = VisitAndConvert(node.Parameters, "VisitLambda");
        
        // ensure parameters set but dont let original reference 
        // be overidden by nested calls
        _parameters = parameters;
    
        return Expression.Lambda(Visit(node.Body), parameters);
    }
