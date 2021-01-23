    public static class DescripionExtractor 
    {
        public static string GetDescription<TValue>(Expression<Func<TValue>> exp) 
        {
            var body = exp.Body as MemberExpression;
            
            if (body == null) 
            {
                throw new ArgumentException("exp");
            }
            var attrs = (DescriptionAttribute[])body.Member.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs.Length == 0) 
            {
                return null;
            }
            return attrs[0].Description;
        }
    }
