    public abstract class PropertyTemplateSelector : DataTemplateSelector
    {
        private Delegate getPropertyValue;
        private string propertyName;
        private Type itemType;
    
        public string PropertyName
        {
            get
            {
                return propertyName;
            }
            set
            {
                propertyName = value;
            }
        }
    
        public Type ItemType
        {
            get
            {
                return itemType;
            }
            set
            {
                itemType = value;
            }
        }
    
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (ItemType.IsInstanceOfType(item))
            {
                if (getPropertyValue == null)
                {
                    System.Linq.Expressions.ParameterExpression instanceParameter =
                        System.Linq.Expressions.Expression.Parameter(item.GetType(), "p");
    
                    System.Linq.Expressions.MemberExpression currentExpression =
                        System.Linq.Expressions.Expression.PropertyOrField(instanceParameter, PropertyName);
    
                    System.Linq.Expressions.LambdaExpression lambdaExpression =
                        System.Linq.Expressions.Expression.Lambda(currentExpression, instanceParameter);
    
                    getPropertyValue = lambdaExpression.Compile();
                }
    
                return SelectTemplateImpl(getPropertyValue.DynamicInvoke(item), container);
            }
    
            return base.SelectTemplate(item, container);
        }
    
        protected abstract DataTemplate SelectTemplateImpl(object propertyValue, DependencyObject container);
    }
