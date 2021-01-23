    .field private initonly string '<ReadOnlyInitialized>k__BackingField'
    // snipped debugger attributes    
    .property instance string ReadOnlyInitialized()
    {
      .get instance string ScratchCsConsole.Program::get_ReadOnlyInitialized()
    } // end of property Program::ReadOnlyInitialized
    .method public hidebysig specialname instance string 
            get_ReadOnlyInitialized() cil managed
    {
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  ldfld      string ScratchCsConsole.Program::'<ReadOnlyInitialized>k__BackingField'
      IL_0006:  ret
    } // end of method Program::get_ReadOnlyInitialized
