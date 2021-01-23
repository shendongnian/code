    /// <summary>
    /// Creates a base.  call method
    ///    Needs to do this so we can skip the unity interception and call
    /// </summary>
    /// <param name="methodInfo"></param>
    /// <returns></returns>
    private static Delegate BaseMethodCall(MethodInfo methodInfo)
    {
        // get parameter types
        // include the calling type to make it an open delegate
        var paramTypes = new[] { methodInfo.DeclaringType.BaseType}.Concat(
            methodInfo.GetParameters().Select(pi => pi.ParameterType)).ToArray();
        var baseCall = new DynamicMethod(string.Empty, methodInfo.ReturnType, paramTypes, methodInfo.Module);
        var il = baseCall.GetILGenerator();
        // add all the parameters into the stack
        for (var i = 0; i < paramTypes.Length; i++)
        {
            il.Emit(OpCodes.Ldarg, i);
        }
        // call the method but not the virtual method 
        //   this is the key to not have the virtual run
        il.EmitCall(OpCodes.Call, methodInfo, null);
        il.Emit(OpCodes.Ret);
        // get the deletage type call of this method
        var delegateType = Expression.GetDelegateType(paramTypes.Concat(new[] { methodInfo.ReturnType}).ToArray());
        return baseCall.CreateDelegate(delegateType);
    }
