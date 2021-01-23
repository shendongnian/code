    .method private hidebysig static void  Main(string[] args) cil managed
    {
      .entrypoint
      // Code size       28 (0x1c)
      .maxstack  2
      .locals init ([0] class ConsoleApplication6.ExampleDelegate sample1,
               [1] class ConsoleApplication6.ExampleDelegate sample2)
      IL_0000:  nop
      IL_0001:  ldnull
      IL_0002:  ldftn      void ConsoleApplication6.Program::SampleMethod()
      IL_0008:  newobj     instance void ConsoleApplication6.ExampleDelegate::.ctor(object,
                                                                                    native int)
      IL_000d:  stloc.0
      IL_000e:  ldnull
      IL_000f:  ldftn      void ConsoleApplication6.Program::SampleMethod()
      IL_0015:  newobj     instance void ConsoleApplication6.ExampleDelegate::.ctor(object,
                                                                                    native int)
      IL_001a:  stloc.1
      IL_001b:  ret
    } // end of method Program::Main
