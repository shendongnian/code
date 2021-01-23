    public static void Main(string[] args)
    {
        var dynamicMethod = new DynamicMethod("PrintHello", typeof(void), null);
        var ilGenerator = dynamicMethod.GetILGenerator();
        ilGenerator.Emit(OpCodes.Ldc_I4_1);
        var toEnd = ilGenerator.DefineLabel();
        ilGenerator.Emit(OpCodes.Brfalse, toEnd);
        ilGenerator.Emit(OpCodes.Ldstr, "Hello");
        ilGenerator.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
        ilGenerator.MarkLabel(toEnd);
        ilGenerator.Emit(OpCodes.Ret);
        var @delegate = (Action)dynamicMethod.CreateDelegate(typeof(Action));
        @delegate();
    }
