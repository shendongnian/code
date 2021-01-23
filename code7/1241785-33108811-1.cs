    public class ApplicationCommand : RelayCommand
        {
    public ApplicationCommand(Expression<Func<ICommand>> property,Action<T> execute, string logName = "")
    {
        // ...
        this.logName = logName;
    }
            public void Execute()
            {
                // No try-catch, I never code bugs ;o)
                Log.Info("Prepare to execute the command " + GetTypeName(this.GetType()) + "." + GetPropertyPath(property));
                base.Execute();
                Log.Info("Finished to execute the command " + GetTypeName(this.GetType()) + "." + GetPropertyPath(property));
            }
        }
    private string GetPropertyPath(LambdaExpression propertyPath, bool acceptsFields = false)
        {
            Stack<MemberInfo> properties = GetPropertyPathStack(propertyPath, acceptsFields);
            return string.Join(".", properties.Select(p => p.Name));
        }
    private Stack<MemberInfo> GetPropertyPathStack(LambdaExpression propertyPath, bool acceptFields = false)
        {
            MemberExpression member = propertyPath.Body as MemberExpression;
            Stack<MemberInfo> properties = new Stack<MemberInfo>();
            while(member != null)
            {
                if (member.Member is PropertyInfo || (acceptFields && member.Member is FieldInfo))
                {
                    properties.Push(member.Member);
                    if (member.Expression is MemberExpression)
                    {
                        member = member.Expression as MemberExpression;
                    }
                    else
                    {
                        ConstantExpression constant = member.Expression as ConstantExpression;
                        member = null;
                    }
                }
                else
                {
                    member = null;
                }
            }
            return properties;
        }
    private string GetTypeName(Type type)
            {
                if (type.IsGenericType)
                {
                    return GetGenericTypeName(type);
                }
                else
                {
                    return type.FullName;
                }
            }
        private string GetGenericTypeName(Type type)
        {
            Type[] genericArguments = type.GetGenericArguments();
            string argumentNames = string.Join(", ", genericArguments.Select(GetTypeName));
            return string.Format("{0}<{1}>", type.GetBaseName(), argumentNames);
        }
