        public static void AttachProperties<T1, T2>(Expression<Func<T1>> property1, Expression<Func<T2>> property2)
        {
            var instance1 = Expression.Lambda<Func<object>>(((MemberExpression)property1.Body).Expression).Compile()();
            var iNotify1 = instance1 as INotifyPropertyChanged;
            var prop1 = GetPropertyInfo(property1);
            var instance2 = Expression.Lambda<Func<object>>(((MemberExpression)property2.Body).Expression).Compile()();
            var iNotify2 = instance2 as INotifyPropertyChanged;
            var prop2 = GetPropertyInfo(property2);
            AttachProperty(prop1, iNotify1, prop2, iNotify2);
            AttachProperty(prop2, iNotify2, prop1, iNotify1);
        }
        static void AttachProperty(
            PropertyInfo property1,
            INotifyPropertyChanged class1Instance,
            PropertyInfo property2,
            INotifyPropertyChanged class2Instance)
        {
            class2Instance.PropertyChanged += (_, propArgs) =>
            {
                if (propArgs.PropertyName == property2.Name || string.IsNullOrEmpty(propArgs.PropertyName))
                {
                    var prop = property2.GetValue(class2Instance);
                    property1.SetValue(class1Instance, prop);
                }
            };
        }
        static PropertyInfo GetPropertyInfo<T1>(Expression<Func<T1>> property)
        {
            MemberExpression expression = null;
            if (property.Body.NodeType == ExpressionType.Convert)
            {
                var body = (UnaryExpression)property.Body;
                expression = body.Operand as MemberExpression;
            }
            else if (property.Body.NodeType == ExpressionType.MemberAccess)
            {
                expression = property.Body as MemberExpression;
            }
            if (expression == null)
            {
                throw new ArgumentException("Not a member access", nameof(property));
            }
            return expression.Member as PropertyInfo;
        }
