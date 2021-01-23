    //  Microsoft (R) .NET Framework IL Disassembler.  Version 4.0.30319.33440
    //  Copyright (c) Microsoft Corporation.  All rights reserved.
    
    
    
    // Metadata version: v4.0.30319
    .assembly extern mscorlib
    {
      .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
      .ver 4:0:0:0
    }
    .assembly testnull
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
      .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                 63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
      .hash algorithm 0x00008004
      .ver 0:0:0:0
    }
    .module testnull.exe
    // MVID: {D8510E3B-5C38-40B9-A5A2-7DAE75DE1642}
    .imagebase 0x00400000
    .file alignment 0x00000200
    .stackreserve 0x00100000
    .subsystem 0x0003       // WINDOWS_CUI
    .corflags 0x00000001    //  ILONLY
    // Image base: 0x00300000
    
    
    // =============== CLASS MEMBERS DECLARATION ===================
    
    .class public auto ansi beforefieldinit C
           extends [mscorlib]System.Object
    {
      .method public hidebysig newslot virtual 
              instance void  M() cil managed
      {
        // Code size       22 (0x16)
        .maxstack  8
        IL_0000:  nop
        IL_0001:  ldstr      "Inside the method M. this == null: {0}"
        IL_0006:  ldarg.0
        IL_0007:  ldnull
        IL_0008:  ceq
        IL_000a:  box        [mscorlib]System.Boolean
        IL_000f:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                      object)
        IL_0014:  nop
        IL_0015:  ret
      } // end of method C::M
    
      .method public hidebysig specialname rtspecialname 
              instance void  .ctor() cil managed
      {
        // Code size       7 (0x7)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
        IL_0006:  ret
      } // end of method C::.ctor
    
    } // end of class C
    
    .class public auto ansi beforefieldinit Program
           extends [mscorlib]System.Object
    {
      .method public hidebysig static void  Main(string[] pars) cil managed
      {
        .entrypoint
        // Code size       11 (0xb)
        .maxstack  1
        .locals init (class C V_0)
        IL_0000:  nop
        IL_0001:  ldnull
        IL_0002:  stloc.0
        IL_0003:  ldloc.0
        IL_0004:  call   instance void C::M()
        IL_0009:  nop
        IL_000a:  ret
      } // end of method Program::Main
    
      .method public hidebysig specialname rtspecialname 
              instance void  .ctor() cil managed
      {
        // Code size       7 (0x7)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
        IL_0006:  ret
      } // end of method Program::.ctor
    
    } // end of class Program
    
    
    // =============================================================
    
    // *********** DISASSEMBLY COMPLETE ***********************
    // WARNING: Created Win32 resource file testnull.res
