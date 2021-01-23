    public TEntity PrepareLogbookProperty<TEntity>(TEntity model, Expression<Func<TEntity, Logbook>> entityExpression)
    {
    	if (model == null)
    	{
    		throw new ArgumentNullException("model");
    	}
    
    	var memberExpression = (MemberExpression)entityExpression.Body;
    	var property = (PropertyInfo)memberExpression.Member;
    
    	var value = property.GetValue(model) as Logbook;
    	value = this.PassLog(value);
    
    	property.SetValue(model, value);
    
    	return model;
    }
