    Type genericType = typeof(string);
    Type typeToInstantiate = typeof(BaseClass<String>).GetInheritingTypes().FirstOrDefault(t=>t.GetGenericsArguments().Contains(genericType));
    if (typeToInstantiate != null)
        MyBaseObject = (BaseClass<T>)Activator.CreateInstance(typeToInstantiate);
    else
        MyBaseObject = new BaseClass<T>();
