        .method private hidebysig static void  Test() cil managed
    {
      // Code size       49 (0x31)
      .maxstack  2
      .locals init ([0] class [mscorlib]System.Func`2<int32,int32> f,
               [1] int32 b)
      IL_0000:  nop
      IL_0001:  ldsfld     class [mscorlib]System.Func`2<int32,int32> ConsoleApplication10.Program::'CS$<>9__CachedAnonymousMethodDelegate1'
      IL_0006:  brtrue.s   IL_001b
      IL_0008:  ldnull
      IL_0009:  ldftn      int32 ConsoleApplication10.Program::'<Test>b__0'(int32)
      IL_000f:  newobj     instance void class [mscorlib]System.Func`2<int32,int32>::.ctor(object,
                                                                                           native int)
      IL_0014:  stsfld     class [mscorlib]System.Func`2<int32,int32> ConsoleApplication10.Program::'CS$<>9__CachedAnonymousMethodDelegate1'
      IL_0019:  br.s       IL_001b
      IL_001b:  ldsfld     class [mscorlib]System.Func`2<int32,int32> ConsoleApplication10.Program::'CS$<>9__CachedAnonymousMethodDelegate1'
      IL_0020:  stloc.0
      IL_0021:  ldloc.0
      IL_0022:  ldc.i4.2
      IL_0023:  callvirt   instance !1 class [mscorlib]System.Func`2<int32,int32>::Invoke(!0)
      IL_0028:  stloc.1
      IL_0029:  ldloc.1
      IL_002a:  call       void [mscorlib]System.Console::WriteLine(int32)
      IL_002f:  nop
      IL_0030:  ret
    } // end of method Program::Test
