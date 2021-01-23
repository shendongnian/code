    foreach (Assembly a in assembliesThatShouldBeCompileed)
        foreach (Type type in a.GetTypes())
            if (!type.IsAbstract && type.IsClass)
            {
                foreach (MethodInfo method in type.GetMethods(
                                    BindingFlags.DeclaredOnly |
                                    BindingFlags.NonPublic |
                                    BindingFlags.Public |
                                    BindingFlags.Instance |
                                    BindingFlags.Static))
                {
                    if (method.ContainsGenericParameters || 
                        method.IsGenericMethod || 
                        method.IsGenericMethodDefinition)
                        continue;
                    if ((method.Attributes & MethodAttributes.PinvokeImpl) > 0)
                        continue;
                    System.Runtime.CompilerServices
                       .RuntimeHelpers.PrepareMethod(method.MethodHandle);
                }
            }
