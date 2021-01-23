     public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.ContainsKey(ParameterName))
            {
                var keyValuePairs = /* function to split parameters */;
                actionContext.ActionArguments[ParameterName] = 
                    keyValuePairs.Select(
                        x => x.Split(new[] { "," }, StringSplitOptions.None))
                            .Select(x => new KeyValuePair<string, string, string>(x[0], x[1], x.Length == 3 ? x[2] : string.Empty))
                            .ToList();                
            }
        }
