    // using Mono.Reflection;
    public static bool ContainsThis(MethodBase method)
    {
        if (method.IsStatic)
        {
            return false;
        }
        IList<Instruction> instructions = method.GetInstructions();
        return instructions.Any(x => x.OpCode == OpCodes.Ldarg_0);
    }
