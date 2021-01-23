    Type propType = prop.GetType();
    if(propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(MyStruct<>))
                {
                 //Do work
                }
