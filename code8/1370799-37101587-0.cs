        var rule = new Rule("State", "NotEqual", "Florida");            
        var dynamicObj = (IDictionary<string, object>) new ExpandoObject();            
        dynamicObj.Add("State", "California");
        var expression = Expression.Parameter(typeof(object), "arg");
        // create a binder like this
        var binder = Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "State", null, new CSharpArgumentInfo[] {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
            });
        // define dynamic property accessor
        var property = Expression.Dynamic(binder, typeof(object), expression);        
        // the rest as usual
        var isValid = false;
        ExpressionType tBinary;
        if (Enum.TryParse(rule.Operator, out tBinary))
        {
            var right = Expression.Constant(rule.TargetValue);
            var result = Expression.MakeBinary(tBinary, property, right);
            var func = typeof(Func<,>).MakeGenericType(dynamicObj.GetType(), typeof(bool));
            var expr = Expression.Lambda(func, result, expression).Compile();
            isValid = (bool)expr.DynamicInvoke(dynamicObj);
        }
