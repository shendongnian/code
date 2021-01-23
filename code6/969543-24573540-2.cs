    .class private auto ansi beforefieldinit ConsoleApplication1.Program
        extends [mscorlib]System.Object
    {
        .method public hidebysig specialname rtspecialname instance void .ctor () cil  managed 
        {
            IL_0000: ldarg.0
            IL_0001: call instance void [mscorlib]System.Object::.ctor()
            IL_0006: ret
        }
        .method private hidebysig static void Main (
                string[] args
            ) cil managed 
        {
            .entrypoint
            IL_0000: nop
            IL_0001: ldstr "Hello, World!"
            IL_0006: call void [mscorlib]System.Console::WriteLine(string)
            IL_000b: nop
            IL_000c: ret
        }
    }
