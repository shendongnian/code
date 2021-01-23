    public Expression Build(Expression provider)
    {
        var parameters = _constructorInfo.GetParameters();
        return Expression.New(
            _constructorInfo,
            _parameterCallSites.Select((callSite, index) =>
                Expression.Convert(
                    callSite.Build(provider),
                    parameters[index].ParameterType)));
    }
