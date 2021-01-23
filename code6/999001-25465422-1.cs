        private IQueryable<TResult> F2<TResult, TParam1, TParam2>(string functionName, string parameterName1,
            TParam1 parameterValue1, string parameterName2,
            TParam2 parameterValue2)
        {
            var queryString = string.Format("[{0}].[{1}](@{2}, @{3})", GetType().Name, functionName, parameterName1, parameterName2);
            var parameter1 = new ObjectParameter(parameterName1, parameterValue1);
            var parameter2 = new ObjectParameter(parameterName2, parameterValue2);
            var query = this.ObjectContext.CreateQuery<TResult>(queryString, parameter1, parameter2);
            return query;
        }
