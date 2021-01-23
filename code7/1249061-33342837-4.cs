    public static Action<T> CreateDelegate<T>(this ConstructorInfo constructor)
        where T: class
    {
        if (constructor == null)
            throw new ArgumentNullException("constructor");
        // Create the dynamic method
        DynamicMethod method = new DynamicMethod(
            constructor.DeclaringType.Name + "_" + Guid.NewGuid().ToString().Replace("-", ""),
            typeof(void),
            new[] { typeof(T) },
            true);
        // Create the il
        ILGenerator ilGenerator = method.GetILGenerator();
        ilGenerator.Emit(OpCodes.Ldarg_0); // Copy the reference to the instance on the stack.
        ilGenerator.Emit(OpCodes.Calli, constructor); // Call the constructor.
        ilGenerator.Emit(OpCodes.Ret); 
        // Return the delegate :)
        return (Action<T>)method.CreateDelegate(typeof(Action<T>));
    }
