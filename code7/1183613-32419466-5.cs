    // be sure to explicitly implement IDictionary<string, object>
    // if needed forwarding all calls to the expando
    class ExtendedExpandoObject : DynamicObject
    {
        public override DynamicMetaObject GetMetaObject(Expression parameter) => new MyMetaObject(parameter, this);
    
        public ExtendedExpandoObject(ExpandoObject expandoObject = null)
        {
            Value = expandoObject ?? new ExpandoObject();
        }
        public ExpandoObject Value { get; }
        
        // the new methods
        public string GetMessage() => "GOT IT!";
        public string GetTypeName<T>() => typeof(T).Name;
    
        // be sure to implement methods to combine results (e.g., GetDynamicMemberNames())
        class MyMetaObject : DynamicMetaObjectWrapper<ExtendedExpandoObject>
        {
            public MyMetaObject(Expression parameter, ExtendedExpandoObject value) : base(parameter, BindingRestrictions.Empty, value)
            {
                var valueParameter = Expression.Property(
                    Expression.Convert(parameter, typeof(ExtendedExpandoObject)),
                    "Value"
                );
                IDynamicMetaObjectProvider provider = value.Value;
                ValueMetaObject = provider.GetMetaObject(valueParameter);
            }
            protected DynamicMetaObject ValueMetaObject { get; }
    
            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                if (IsMember(binder.Name))
                    return base.BindGetMember(binder);
                return ValueMetaObject.BindGetMember(binder);
            }
    
            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
            {
                if (IsMember(binder.Name))
                    return base.BindSetMember(binder, value);
                return ValueMetaObject.BindSetMember(binder, value);
            }
    
            private bool IsMember(string name) => typeof(ExtendedExpandoObject).GetMember(name).Any();
        }
    }
