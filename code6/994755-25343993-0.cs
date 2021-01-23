    /// <summary>
    /// Given a concrete generic type instantiation T&lt;t_1, t_2, ...>, where any number of the t_i may be type builders,
    /// and given a method M on the generic type definition T&lt;>, return the corresponding method on the concrete type
    /// </summary>
    static MethodInfo GetConcreteMethodInfo(Type concreteClass, MethodInfo genericTypeMethod)
    {
        var substitution = concreteClass.GetGenericTypeDefinition().GetGenericArguments()
                            .Zip(concreteClass.GetGenericArguments(), (t1, t2) => Tuple.Create(t1, t2))
                            .ToDictionary(t => t.Item1, t => t.Item2);
        var declaredMethod = genericTypeMethod.DeclaringType.Module.ResolveMethod(genericTypeMethod.MetadataToken);
        var declaringTypeGeneric = declaredMethod.DeclaringType;  // typeof(Collection<>)
        var declaringTypeRelative = genericTypeMethod.DeclaringType; // typeof(Collection<BindingList<T>.T>)
        // now get the concrete type by applying the substitution
        var declaringTypeConcrete = // typeof(Collection<myClass>)
            declaringTypeGeneric.MakeGenericType(Array.ConvertAll(declaringTypeRelative.GetGenericArguments(),
                                                    t => substitution.ContainsKey(t) ? substitution[t] : t));
        return TypeBuilder.GetMethod(declaringTypeConcrete, (MethodInfo)declaredMethod);
    }
