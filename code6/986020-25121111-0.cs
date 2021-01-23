    public string GetJsonResult(string method, params object[] arguments)
    {
        var methodInfo = this.GetType().GetMethod(method);
        var methodParameters = methodInfo.GetParameters();
        var parameters = new List<object>();
        for (int i = 0; i < methodParameters.Length; i++)
        {
            //  Here I'm getting the parameter name and value that was sent
            //  on the arguments array, we need to assume that every
            //  argument will come as 'parameterName=parameterValue'
            var pName = arguments[i].ToString().Split('=')[0];
            var pValue = arguments[i].ToString().Split('=')[1];
            //  This way I can get the exact type for the argument name that I'm sending.
            var pInfo = methodParameters.First(x => x.Name == pName);
            parameters.Add(Convert.ChangeType(pValue,
                //  This is needed because we may be sending a parameter that is Nullable.
                Nullable.GetUnderlyingType(pInfo.ParameterType) ?? pInfo.ParameterType));
        }
        var l = methodInfo.Invoke(this, parameters.ToArray());
        return new JavaScriptSerializer().Serialize(l);
    }
