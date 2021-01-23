    public static void DoStuffWithParameter<T>(Expression<Func<T>> paramExpression)
    {
            if (paramExpression == null) throw new ArgumentNullException("paramExpression");
            var body = ((MemberExpression)paramExpression.Body);
            var paramName = body.Member.Name;
            var param = ((FieldInfo)body.Member)
                 .GetValue(((ConstantExpression)body.Expression).Value);
            var declaringType = param.DeclaringType;
            var paramValue =  paramExpression
        .Compile()
        .Invoke();
            if(declaringType.Equals(typeof(ClassA)))
            {
                //do stuff 
            }
    }       
