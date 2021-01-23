    .class private auto ansi '<Module>'
    {
    } // end of class <Module>
    
    .class public auto ansi beforefieldinit C
        extends [mscorlib]System.Object
    {
        // Methods
        .method public hidebysig 
            instance void M () cil managed 
        {
            // Method begins at RVA 0x2050
            // Code size 19 (0x13)
            .maxstack 8
    
            IL_0000: nop
            IL_0001: call void [mscorlib]System.Console::WriteLine()
            IL_0006: nop
            IL_0007: ldsfld string [mscorlib]System.String::Empty
            IL_000c: call void [mscorlib]System.Console::WriteLine(string)
            IL_0011: nop
            IL_0012: ret
        } // end of method C::M
    
        .method public hidebysig specialname rtspecialname 
            instance void .ctor () cil managed 
        {
            // Method begins at RVA 0x2064
            // Code size 8 (0x8)
            .maxstack 8
    
            IL_0000: ldarg.0
            IL_0001: call instance void [mscorlib]System.Object::.ctor()
            IL_0006: nop
            IL_0007: ret
        } // end of method C::.ctor
    
    } // end of class C
