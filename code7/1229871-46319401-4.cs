    public static Dictionary<string, object> ToParametersDictionary(this DynamicParameters dynamicParams)
    {
        var argsDictionary = new Dictionary<String, Object>();
        var iLookup = (SqlMapper.IParameterLookup) dynamicParams;
        //if (dynamicParams.ParameterNames.Any())
        //{
            // read the parameters added via dynamicParams.Add("NAME", value)
            foreach (var paramName in dynamicParams.ParameterNames)
            {
                var value = iLookup[paramName];
                argsDictionary.Add(paramName, value);
            }
        //}
        //else
        //{
            // read the "templates" field containing dynamic parameters section added
            // via dynamicParams.Add(new {PARAM_1 = value1, PARAM_2 = value2});
            var templates = dynamicParams.GetType().GetField("templates", BindingFlags.NonPublic | BindingFlags.Instance);
            if (templates != null)
            {
                var list = templates.GetValue(dynamicParams) as List<Object>;
                if (list != null)
                {
                    // add properties of each dynamic parameters section
                    foreach (var objProps in list.Select(obj => obj.GetPropertyValuePairs().ToList()))
                    {
                        objProps.ForEach(p => argsDictionary.Add(p.Key, p.Value));
                    }
                }
            }
        }
        return argsDictionary;
    }
