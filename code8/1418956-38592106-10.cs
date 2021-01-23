    .method private hidebysig static void  Main(string[] args) cil managed
    {
      .entrypoint
      // Code size       85 (0x55)
      .maxstack  1
      .locals init ([0] class SandboxConsole.TestClass context)
      IL_0000:  newobj     instance void SandboxConsole.TestClass::.ctor()
      IL_0005:  stloc.0
      .try
      {
        IL_0006:  call       void [mscorlib]System.GC::Collect()
        IL_000b:  call       void [mscorlib]System.GC::WaitForPendingFinalizers()
        IL_0010:  call       void [mscorlib]System.GC::Collect()
        IL_0015:  ldstr      "After collection"
        IL_001a:  call       void [mscorlib]System.Console::WriteLine(string)
        IL_001f:  leave.s    IL_002b
      }  // end .try
      finally
      {
        IL_0021:  ldloc.0
        IL_0022:  brfalse.s  IL_002a
        IL_0024:  ldloc.0
        IL_0025:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_002a:  endfinally
      }  // end handler
      IL_002b:  ldstr      "After dispose, before 2nd collection"
      IL_0030:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_0035:  call       void [mscorlib]System.GC::Collect()
      IL_003a:  call       void [mscorlib]System.GC::WaitForPendingFinalizers()
      IL_003f:  call       void [mscorlib]System.GC::Collect()
      IL_0044:  ldstr      "After 2nd collection"
      IL_0049:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_004e:  call       string [mscorlib]System.Console::ReadLine()
      IL_0053:  pop
      IL_0054:  ret
    } // end of method Program::Main
