    .method private hidebysig static void Main (
            string[] args
        ) cil managed 
    {
        .entrypoint
        .locals init (
            [0] class [mscorlib]System.WeakReference weakRef
        )
        IL_0000: newobj instance void _GC.Program/TestClass::.ctor()
        IL_0005: newobj instance void [mscorlib]System.WeakReference::.ctor(object)
        IL_000a: stloc.0
        IL_000b: ldstr "Leaving the block"
        IL_0010: call void [mscorlib]System.Console::WriteLine(string)
        IL_0015: ldstr "GC.Collect()"
        IL_001a: call void [mscorlib]System.Console::WriteLine(string)
        IL_001f: call void [mscorlib]System.GC::Collect()
        IL_0024: ldc.i4 1000
        IL_0029: call void [mscorlib]System.Threading.Thread::Sleep(int32)
        IL_002e: ldstr "weakRef.IsAlive == {0}"
        IL_0033: ldloc.0
        IL_0034: callvirt instance bool [mscorlib]System.WeakReference::get_IsAlive()
        IL_0039: box [mscorlib]System.Boolean
        IL_003e: call void [mscorlib]System.Console::WriteLine(string,  object)
        IL_0043: ldstr "Leaving the program"
        IL_0048: call void [mscorlib]System.Console::WriteLine(string)
        IL_004d: ret
    }
