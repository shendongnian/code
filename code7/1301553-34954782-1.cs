    .method public hidebysig static int32  f(int32 n) cil managed
    {
      // Code size       25 (0x19)
      .maxstack  2
      .locals init ([0] int32[] arr,
               [1] int32 V_1)
      IL_0000:  nop
      IL_0001:  ldc.i4.0
      IL_0002:  ldarg.0
      IL_0003:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<int32> [System.Core]System.Linq.Enumerable::Range(int32,
                                                                                                                                      int32)
      IL_0008:  call       !!0[] [System.Core]System.Linq.Enumerable::ToArray<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
      IL_000d:  stloc.0
      IL_000e:  ldloc.0
      IL_000f:  call       int32 [System.Core]System.Linq.Enumerable::Max(class [mscorlib]System.Collections.Generic.IEnumerable`1<int32>)
      IL_0014:  stloc.1
      IL_0015:  br.s       IL_0017
      IL_0017:  ldloc.1
      IL_0018:  ret
    } // end of method Program::f
