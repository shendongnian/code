    public void Main()
    {
        string str = "My Name is @MyClass.FirstName @MyClass.LastName";
        var me = new MyClass { FirstName = "foo", LastName = "bar" };
        ReflectionReplace(str, me);
    }
    
    public string ReflectionReplace<T>(string template, T obj)
    {    
        foreach (var property in typeof(T).GetProperties())
        {
            var stringToReplace = "@" + typeof(T).Name + "." + property.Name;
            var value = property.GetValue(obj);
            if (value == null) value = "";
            template = template.Replace(stringToReplace, value.ToString());
        }
        return template;
    }
