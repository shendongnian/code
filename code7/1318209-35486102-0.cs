    var parameter = Expression.Parameter(typeof(T), expression.Value.Parameters[0].Name);
     
    Expression body = new ReplaceVisitor<string>(expression.Value.Parameters[1], right).Visit(expression.Value.Body);                   
    
    var lambda =  Expression.Lambda<Func<T, bool>>(body, parameter);
                   
