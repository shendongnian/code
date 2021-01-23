    public class FieldWrapper<T, O>
    {
        private T _item;
        private O _owner;
        private PropertyInfo _setter;
        public T Value
        {
             get { return _item; }
             set {
               if (!EqualityComparer<T>.Default.Equal(_item, value))
               {
                    _item = value;
                    // do some personal check
                    _setter.SetValue(_owner, value);
               }
             }
        }
        public bool someBool;
        public int someCounter;
        // ..whatever
        // CTOR
        public FieldWrapper(O owner, Expression<Func<T, O>> propertyExpressionInTheOwner)
        {
           _owner = owner;
           propertyName = (propertyExpressionInTheOwner.body as MemberExpression).Member.Name;
           // get PropertyInfo using the owner and propertyName
        }
    }
