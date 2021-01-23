    public B(A a)
    {
        var bType = this.GetType();
        var aProps = a.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var prop in aProps)
            bType.GetProperty(prop.Name).SetValue(this, prop.GetValue(a));
    }
