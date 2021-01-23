    .method private hidebysig static 
        string LastLine1 (
            class [System]System.Net.Sockets.NetworkStream networkStream
        ) cil managed 
    {
        .maxstack 2
        .locals init (
            [0] string,
            [1] class [mscorlib]System.IO.StreamReader,
            [2] string,
            [3] class [mscorlib]System.IO.StreamReader
        )
        IL_0000: ldnull
        IL_0001: stloc.0
        IL_0002: br.s IL_0025
        IL_0004: ldarg.0
        IL_0005: newobj instance void [mscorlib]System.IO.StreamReader::.ctor(class [mscorlib]System.IO.Stream)
        IL_000a: dup
        IL_000b: stloc.1
        IL_000c: stloc.3
        .try
        {
            IL_000d: ldloc.1
            IL_000e: callvirt instance string [mscorlib]System.IO.TextReader::ReadLine()
            IL_0013: stloc.2
            IL_0014: ldloc.2
            IL_0015: brfalse.s IL_0019
            IL_0017: ldloc.2
            IL_0018: stloc.0
            IL_0019: leave.s IL_0025
        }
        finally
        {
            IL_001b: ldloc.3
            IL_001c: brfalse.s IL_0024
            IL_001e: ldloc.3
            IL_001f: callvirt instance void [mscorlib]System.IDisposable::Dispose()
            IL_0024: endfinally
        }
        IL_0025: call bool Demonstrate.Program::get_ShouldStop()
        IL_002a: brfalse.s IL_0004
        IL_002c: ldloc.0
        IL_002d: ret
    }
    .method private hidebysig static 
        string LastLine2 (
            class [System]System.Net.Sockets.NetworkStream networkStream
        ) cil managed 
    {
        .maxstack 1
        .locals init (
            [0] string,
            [1] class [mscorlib]System.IO.StreamReader,
            [2] string
        )
        IL_0000: ldnull
        IL_0001: stloc.0
        IL_0002: br.s IL_0023
        IL_0004: ldarg.0
        IL_0005: newobj instance void [mscorlib]System.IO.StreamReader::.ctor(class [mscorlib]System.IO.Stream)
        IL_000a: stloc.1
        .try
        {
            IL_000b: ldloc.1
            IL_000c: callvirt instance string [mscorlib]System.IO.TextReader::ReadLine()
            IL_0011: stloc.2
            IL_0012: ldloc.2
            IL_0013: brfalse.s IL_0017
            IL_0015: ldloc.2
            IL_0016: stloc.0
            IL_0017: leave.s IL_0023
        }
        finally
        {
            IL_0019: ldloc.1
            IL_001a: brfalse.s IL_0022
            IL_001c: ldloc.1
            IL_001d: callvirt instance void [mscorlib]System.IDisposable::Dispose()
            IL_0022: endfinally
        }
        IL_0023: call bool Demonstrate.Program::get_ShouldStop()
        IL_0028: brfalse.s IL_0004
        IL_002a: ldloc.0
        IL_002b: ret
    }
