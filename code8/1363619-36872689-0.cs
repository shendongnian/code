    public class BaseClass
    {
        public BaseClass(int value)
        {
            SetValue(x => x.MyField, value);
        }
    
        public int MyField;
    
        public void SetValue<TField>(Expression<Func<BaseClass, TField>> memberSelector, TField value)
        {
            var expression = memberSelector.Body as MemberExpression;
            if (expression == null)
                throw new MemberAccessException();
            
            this.GetType().GetField(expression.Member.Name)
                .SetValue(this, value);
        }
    }
