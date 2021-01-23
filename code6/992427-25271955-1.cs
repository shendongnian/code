    public class DynamicBreezeEntity : BaseEntity, IDynamicMetaObjectProvider
    {
        private readonly Dictionary<string, PropertyDefinition> _properties;
        public DynamicBreezeEntity ()
        {
            _properties = new Dictionary<string, PropertyDefinition>();
        }
        public void DefineProperty(string name, Type type, bool isNullable = false)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (_properties.ContainsKey(name))
                throw new ArgumentException("Property already defined.", "name");
            if (type == null)
                throw new ArgumentNullException("type");
            if (isNullable && !type.IsValueType)
                throw new ArgumentException("Only value types can be nullable.", "type");            
            if (isNullable)
            {
                type = Nullable.GetUnderlyingType(type);
                if (type.IsValueType)
                    type = typeof(Nullable<>).MakeGenericType(type);
            }
            _properties.Add(name, new PropertyDefinition { Type = type });
        }
        public object GetValue(string name)
        {
            PropertyDefinition def;
            if (_properties.TryGetValue(name, out def))
                return def.Value;
            throw new ArgumentException("Property not defined.", "name");
        }
        public void SetValue(string name, object value)
        {
            // more work todo here: handle value == null correctly
            PropertyDefinition def;
            if (_properties.TryGetValue(name, out def) && def.Type.IsAssignableFrom(value.GetType()))            
                def.Value = value;
            throw new ArgumentException("Property not defined.", "name");
        }
        public IEnumerable<string> GetPropertyNames()
        {
            return _properties.Keys.ToList();
        }
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return new Proxy(this);
        }   
        private class PropertyDefinition
        {
            public Type Type { get; set; }
 
            public object Value { get; set; }
        }
        private class Proxy : DynamicMetaObject 
        {
             public Proxy(DynamicBreezeEntity host, Expression expression)
                 : this(host, expression, BindingRestrictions.Empty) { }
             public Proxy(DynamicBreezeEntity host, Expression expression, BindingRestrictions restrictions)
                 : base(expressiom restrictions, host) { }
             private DynamicBreezeEntity Host
             {
                 get { return (DynamicBreezeEntity)Value; }
             }
             private BindingRestrictions GetBindingRestrictions()
             {
                 var restrictions = BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType);
                 return restrictions.Merge(BindingRestrictions.GetInstanceRestriction(this.Expression, this.Host));            
             }
             public override IEnumerable<string> GetDynamicMemberNames()
             {
                 return this.Host.GetPropertyNames();
             }
             public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
             {
                var arguments = new Expression[] { Expression.Constant(binder.Name) };
                var method = typeof(DynamicBreezeEntity).GetMethod("GetValue");
    
                var callExpression = Expression.Convert(Expression.Call(Expression.Convert(this.Expressiom, this.LimitType), method, arguments), binder.ReturnType);
                return new DynamicMetaObject(callExpression, GetBindingRestrictions());
             }
             public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
             {
                 var arguments = new Expression[] {
                     Expression.Constant(binder.Name),
                     Expression.Convert(value.Expression, typeof(object))
                 };
                 var method = typeof(DynamicBreezeEntity).GetMethod("SetValue");
                 return new DynamicMetaObject(
                     Expression.Call(Expression.Convert(this.Expression, this.LimitType), method, arguments),
                     this.GetBindingRestrictions()
                 );
             }
        }
    }
