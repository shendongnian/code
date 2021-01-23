      .locals init ([0] class Test.Program/'<>c__DisplayClass1' 'CS$<>8__locals2',
               [1] class [mscorlib]System.Exception exception,
               [2] string[] CS$0$0000)
      IL_0000:  nop
      .try
      {
        IL_0001:  newobj     instance void Test.Program/'<>c__DisplayClass1'::.ctor()
        IL_0006:  stloc.0
        IL_0007:  nop
        IL_0008:  ldloc.0
        IL_0009:  ldc.i4.1
        IL_000a:  newarr     [mscorlib]System.String
        IL_000f:  stloc.2
        IL_0010:  ldloc.2
        IL_0011:  ldc.i4.0
        IL_0012:  ldstr      "1"
        IL_0017:  stelem.ref
        IL_0018:  ldloc.2
        IL_0019:  stfld      string[] Test.Program/'<>c__DisplayClass1'::one
        IL_001e:  ldc.i4.1
        IL_001f:  ldc.i4.1
        IL_0020:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<int32> [System.Core]System.Linq.Enumerable::Range(int32,
                                                                                                                                        int32)
        IL_0025:  ldloc.0
        IL_0026:  ldftn      instance bool Test.Program/'<>c__DisplayClass1'::'<Main>b__0'(int32)
        IL_002c:  newobj     instance void class [mscorlib]System.Func`2<int32,bool>::.ctor(object,
                                                                                            native int)
        IL_0031:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Where<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                                                                             class [mscorlib]System.Func`2<!!0,bool>)
        IL_0036:  pop
        IL_0037:  nop
        IL_0038:  leave.s    IL_004a
      }  // end .try
      catch [mscorlib]System.Exception 
      {
