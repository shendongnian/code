    IList targetList = (IList)listPropertyInfo.GetValue(item);
    Type foo = targetList.GetType().GenericTypeArguments.Single();
    Type unboundGenericType = typeof(READ<>);
    Type boundGenericType = unboundGenericType.MakeGenericType(foo);
    MethodInfo doSomethingMethod = boundGenericType.GetMethod("trigger");
    object instance = Activator.CreateInstance(boundGenericType);
    doSomethingMethod.Invoke(instance, new object[] { targetList, f, properties });
