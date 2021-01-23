    private System.Linq.Expressions.Expression<Func<T, bool>> GetExpression<T>()
    {
        var param = System.Linq.Expressions.Expression.Parameter(typeof(T));
        //In silverlight, the path would be this I think.
        //var filteredExpression = radDataFilter.ViewModel.CompositeFilter.Descriptor.CreateFilterExpression(param);
        var filteredExpression = radDataFilter.FilterDescriptors.CreateFilterExpression(param);
        
        if (filteredExpression is System.Linq.Expressions.ConstantExpression)
        {
            //"CreateFilterExpression(param) returns "Expression.Constant(OperatorValueFilterDescriptorBase.UnsetValue)" when no filter is applied.
            //We just return true for all rows when that happens.
            return (x) => true;
        }
        return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(filteredExpression, param);
    }
