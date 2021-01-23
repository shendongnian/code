    private static string namespacePrefix = "MyNamespace.";
    public static Form CreateFormByName(string formName)
    {
        Assembly myAssembly = Assembly.GetExecutingAssembly();
        Type formType = myAssembly.GetType(namespacePrefix + FormName);
        return (Form)Activator.CreateInstance(formType);
    }
