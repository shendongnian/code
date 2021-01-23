    public virtual Expression<Func<T, object>> UpdateCriterion()
    {
        
        return e => new { GetPropertyValue<T>(e,"id"), GetPropertyValue<T>(e,"CompanyId") }; 
    }
    public object GetPropertyValue<T>(T TargetObject,string PropertyName)
    {
         var prop = typeof(T).GetProperty(PropertyName).GetValue(TargetObject, null);
    }
