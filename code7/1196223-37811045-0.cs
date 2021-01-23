    using System.Reflection;
    
    string tableName = typeof(MyClass).Name;
    var customAttributes = typeof(MyClass).GetTypeInfo().GetCustomAttributes<SQLite.Net.Attributes.TableAttribute>();
    if(customAttributes.Count() > 0)
    {
        tableName = customAttributes.First().Name;
    }
