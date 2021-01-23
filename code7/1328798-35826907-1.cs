    using System.Reflection;
    PropertyInfo[] props = typeof(Item).GetProperties();
    for(int i = 0; i < props.Length; i++)
    {
        string ParamName = props[i].Name;
    }
