    IEnumerable<PropertyInfo> props = from n in typeof(MyClass).GetProperties()
                                      let get = n.GetGetMethod()
                                      let set = n.GetSetMethod()
                                      where get != null && set != null &&
                                            n.DeclaringType == typeof(MyClass)
                                      select n;
    foreach (PropertyInfo info in props)
    {
        // Code goes here. Something like:
        object obj = info.GetValue(instanceOfMyClass);
    }
