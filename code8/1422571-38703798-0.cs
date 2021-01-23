    IL_0000: nop
    IL_0001: ldsfld class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Func`3<class [System.Core]System.Runtime.CompilerServices.CallSite, object, int32>> class Test.Program/'<>o__0`1'<!!T>::'<>p__0'
    IL_0006: brfalse.s IL_000a
    IL_0008: br.s IL_002e
    IL_000a: ldc.i4.0
    IL_000b: ldtoken [mscorlib]System.Int32
    IL_0010: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_0015: ldtoken Test.Program
    IL_001a: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_001f: call class [System.Core]System.Runtime.CompilerServices.CallSiteBinder [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.Binder::Convert(valuetype [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags,  class [mscorlib]System.Type,  class [mscorlib]System.Type)
    IL_0024: call class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Func`3<class [System.Core]System.Runtime.CompilerServices.CallSite, object, int32>> class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Func`3<class [System.Core]System.Runtime.CompilerServices.CallSite, object, int32>>::Create(class [System.Core]System.Runtime.CompilerServices.CallSiteBinder)
    IL_0029: stsfld class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Func`3<class [System.Core]System.Runtime.CompilerServices.CallSite, object, int32>> class Test.Program/'<>o__0`1'<!!T>::'<>p__0'
    IL_002e: ldsfld class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Func`3<class [System.Core]System.Runtime.CompilerServices.CallSite, object, int32>> class Test.Program/'<>o__0`1'<!!T>::'<>p__0'
    IL_0033: ldfld !0 class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Func`3<class [System.Core]System.Runtime.CompilerServices.CallSite, object, int32>>::Target
    IL_0038: ldsfld class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Func`3<class [System.Core]System.Runtime.CompilerServices.CallSite, object, int32>> class Test.Program/'<>o__0`1'<!!T>::'<>p__0'
    IL_003d: ldarg.0
    IL_003e: box !!T
    IL_0043: callvirt instance int32 class [mscorlib]System.Func`3<class [System.Core]System.Runtime.CompilerServices.CallSite, object, int32>::Invoke(!0,  !1)
    IL_0048: stloc.0
    IL_0049: ret
