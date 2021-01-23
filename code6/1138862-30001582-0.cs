    public Control CreateControlByTypeName(string typeName) {
        string fullName = string.Format("System.Windows.Controls.{0}", typeName);
        Type type = Type.GetType(fullName);
        return (Control)Activator.CreateInstance(type);
    }
