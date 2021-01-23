    public static R CopyMethod<T, R>(Func<T, R> f, T t)
    {
        AppDomain currentDom = Thread.GetDomain();
        AssemblyName asm = new AssemblyName("DynamicAssembly");
        AssemblyBuilder abl = currentDom.DefineDynamicAssembly(asm, AssemblyBuilderAccess.Run);
        ModuleBuilder mbl = abl.DefineDynamicModule("Module");
        TypeBuilder tbl = mbl.DefineType("Type");
        MethodInfo info = f.GetMethodInfo();
        MethodBuilder mtbl = tbl.DefineMethod(info.Name, info.Attributes, info.CallingConvention, info.ReturnType, info.GetParameters().Select(x => x.ParameterType).ToArray());
        MethodBody mb = f.Method.GetMethodBody();
        byte[] il = mb.GetILAsByteArray();
        ILGenerator ilg = mtbl.GetILGenerator();
        foreach (var local in mb.LocalVariables)
            ilg.DeclareLocal(local.LocalType);
        for (int i = 0; i < opCodes.Length; ++i)
        {
            if (!opCodes[i].code.HasValue)
                continue;
            OpCode opCode = opCodes[i].code.Value;
            if (opCode.OperandType == OperandType.InlineBrTarget)
            {
                ilg.Emit(opCode, BitConverter.ToInt32(il, i + 1));
                i += 4;
                continue;
            }
            if (opCode.OperandType == OperandType.ShortInlineBrTarget)
            {
                ilg.Emit(opCode, il[i + 1]);
                ++i;
                continue;
            }
            if (opCode.OperandType == OperandType.InlineType)
            {
                Type tp = info.Module.ResolveType(BitConverter.ToInt32(il, i + 1), info.DeclaringType.GetGenericArguments(), info.GetGenericArguments());
                ilg.Emit(opCode, tp);
                i += 4;
                continue;
            }
            if (opCode.FlowControl == FlowControl.Call)
            {
                MethodInfo mi = info.Module.ResolveMethod(BitConverter.ToInt32(il, i + 1)) as MethodInfo;
                if (mi == info)
                    ilg.Emit(opCode, mtbl);
                else
                    ilg.Emit(opCode, mi);
                i += 4;
                continue;
            }
            ilg.Emit(opCode);
        }
    
        Type type = tbl.CreateType();
        Func<T, R> method = type.GetMethod(info.Name).CreateDelegate(typeof(Func<T, R>)) as Func<T, R>;
        return method(t);
    }
    
    static OpCodeContainer[] GetOpCodes(byte[] data)
    {
        List<OpCodeContainer> opCodes = new List<OpCodeContainer>();
        foreach (byte opCodeByte in data)
            opCodes.Add(new OpCodeContainer(opCodeByte));
        return opCodes.ToArray();
    }
    
    class OpCodeContainer
    {
        public OpCode? code;
        byte data;
    
        public OpCodeContainer(byte opCode)
        {
            data = opCode;
            try
            {
                code = (OpCode)typeof(OpCodes).GetFields().First(t => ((OpCode)(t.GetValue(null))).Value == opCode).GetValue(null);
            }
            catch { }
        }
    }
