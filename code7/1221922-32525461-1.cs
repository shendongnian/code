    private static string namespacePrefix = "MyNamespace.";
    public static Form CreateFormByName(string formName)
    {
        Assembly myAssembly = Assembly.GetExecutingAssembly();
        Type formType = myAssembly.GetType(namespacePrefix + formName);
        if (formType == null)
            throw new ArgumentException("Form type not found");
        return (Form)Activator.CreateInstance(formType);
    }
