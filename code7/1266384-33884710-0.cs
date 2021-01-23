  IL_0015:  newobj     instance void [mscorlib]System.Action::.ctor(object,
                                                                    native int)
  IL_001a:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Combine(class [mscorlib]System.Delegate,
                                                                                          class [mscorlib]System.Delegate)
  IL_001f:  castclass  [mscorlib]System.Action
  IL_0024:  stfld      class [mscorlib]System.Action ConsoleTests.Program6/Chunk::OnTrigger
  IL_0029:  ldloc.0
  IL_002a:  ldfld      class ConsoleTests.Program6/Leaf ConsoleTests.Program6/Chunk::leaf
  IL_002f:  dup
  IL_0030:  ldfld      class [mscorlib]System.Action ConsoleTests.Program6/Leaf::OnTrigger
  IL_0035:  ldloc.0
  IL_0036:  ldfld      class [mscorlib]System.Action ConsoleTests.Program6/Chunk::OnTrigger
  IL_003b:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Combine(class [mscorlib]System.Delegate,
                                                                                          class [mscorlib]System.Delegate)
  IL_0040:  castclass  [mscorlib]System.Action
  IL_0045:  stfld      class [mscorlib]System.Action ConsoleTests.Program6/Leaf::OnTrigger
  IL_004a:  ldloc.0
  IL_004b:  dup
  IL_004c:  ldfld      class [mscorlib]System.Action ConsoleTests.Program6/Chunk::OnTrigger
  IL_0051:  ldnull
  IL_0052:  ldftn      void ConsoleTests.Program6::World()
  IL_0058:  newobj     instance void [mscorlib]System.Action::.ctor(object,
                                                                    native int)
  IL_005d:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Combine(class [mscorlib]System.Delegate,
                                                                                          class [mscorlib]System.Delegate)
  IL_0062:  castclass  [mscorlib]System.Action
  IL_0067:  stfld      class [mscorlib]System.Action ConsoleTests.Program6/Chunk::OnTrigger
  IL_006c:  ldloc.0
  IL_006d:  ldfld      class ConsoleTests.Program6/Leaf ConsoleTests.Program6/Chunk::leaf
  IL_0072:  callvirt   instance void ConsoleTests.Program6/Leaf::Go()
