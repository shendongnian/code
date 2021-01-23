    .property instance string ReadOnlyLambda()
    {
      .get instance string ScratchCsConsole.Program::get_ReadOnlyLambda()
    } // end of property Program::ReadOnlyLambda
    .method public hidebysig specialname instance string 
            get_ReadOnlyLambda() cil managed
    {
      // Code size       6 (0x6)
      .maxstack  8
      IL_0000:  ldstr      "String B"
      IL_0005:  ret
    } // end of method Program::get_ReadOnlyLambda
