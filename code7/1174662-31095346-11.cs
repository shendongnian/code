    .method private hidebysig static void  Main(string[] args) cil managed
    {
      .entrypoint
      // Code size       56 (0x38)
      .maxstack  1
      .locals init ([0] class ConsoleApplication1.Test test,
               [1] valuetype [mscorlib]System.DateTime CS$0$0000)
      IL_0000:  nop
      IL_0001:  newobj     instance void ConsoleApplication1.Test::.ctor()
      IL_0006:  stloc.0
      IL_0007:  ldloc.0
      IL_0008:  callvirt   instance string ConsoleApplication1.Test::get_Name() //here
      IL_000d:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_0012:  nop
      IL_0013:  ldloc.0
      IL_0014:  callvirt   instance string ConsoleApplication1.Test::GetName()//here
      IL_0019:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_001e:  nop
      IL_001f:  call       valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Today()//here
      IL_0024:  stloc.1
      IL_0025:  ldloca.s   CS$0$0000
      IL_0027:  call       instance valuetype [mscorlib]System.DayOfWeek [mscorlib]System.DateTime::get_DayOfWeek()
      IL_002c:  box        [mscorlib]System.DayOfWeek
      IL_0031:  call       void [mscorlib]System.Console::WriteLine(object)
      IL_0036:  nop
      IL_0037:  ret
    } // end of method Program::Main
