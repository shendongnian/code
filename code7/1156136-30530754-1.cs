    public static string GetContent(Type type, string controllerName) 
    {
        foreach (MethodInfo method in type.GetMethods(BindingFlags.Static | BindingFlags.Public))
        {
            ControllerNameAttribute controller = (ControllerNameAttribute)method.GetCustomAttribute(typeof(ControllerNameAttribute));
            if (controller == null)
            {
                continue;
            }
            if (controller.Name != controllerName)
            {
                continue;
            }
            if (method.IsGenericMethod)
            {
                throw new InvalidOperationException();
            }
            if (method.GetParameters().Length != 0)
            {
                throw new InvalidOperationException();
            }
            if (method.ReturnType != typeof(string))
            {
                throw new InvalidOperationException();
            }
            string result = (string)method.Invoke(null, null);
            return result;
        }
        throw new InvalidOperationException();
    }
