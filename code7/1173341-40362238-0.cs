        public override T Find(params object[] keyValues)
        {
            ParameterExpression _ParamExp = Expression.Parameter(typeof(T), "a");
            Expression _BodyExp = null;
            Expression _Prop = null;
            Expression _Cons = null;
            PropertyInfo[] props = typeof(T).GetProperties();
            var typeName = typeof(T).Name.ToLower() + "id";
            var key = props.Where(p => (p.Name.ToLower().Equals("id")) || (p.Name.ToLower().Equals(typeName))).Single();
            _Prop = Expression.Property(_ParamExp, key.Name);
            _Cons = Expression.Constant(keyValues.Single(), key.PropertyType);
            _BodyExp = Expression.Equal(_Prop, _Cons);
  
            var _Lamba = Expression.Lambda<Func<T, Boolean>>(_BodyExp, new ParameterExpression[] { _ParamExp });
            return this.SingleOrDefault(_Lamba);
        }
    
