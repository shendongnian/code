    public static Task InfoAsync(string message)
    {
        if (_logTypes.Contains(InfoLogType))
        {
            string applicationName, methodName, className;
            ReflectClassAndMethod(out applicationName, out className, out methodName);
            return WriteAsync(applicationName, "Info", className, methodName, message);
        }
    }
