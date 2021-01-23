    public class ApplicationCommand : RelayCommand
        {
            public void Execute()
            {
                // No try-catch, I never code bugs ;o)
                Log.Info("Prepare to execute the command " + GetTypeName(this.GetType()));
                base.Execute();
                Log.Info("Finished to execute the command " + GetTypeName(this.GetType()));
            }
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
