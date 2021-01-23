    .method public hidebysig static 
      void Maybe (
        int32 a,
        int32 b
      ) cil managed 
    {
      ldarg.0           // Load first argument onto stack
      ldarg.1           // Load second argument onto stack
      ble.s IL_000e     // Pop two values from stack. If the first is
                        // less than or equal to the second, goto IL_000e: 
      ldstr "Greater"   // Load string "Greater" onto stack.
                        // Call Console.WriteLine(string)
      call void [mscorlib]System.Console::WriteLine(string)
                        // Load string "Done" onto stack.
      IL_000e: ldstr "Done"
                        // Call Console.WriteLine(string)
      call void [mscorlib]System.Console::WriteLine(string)
      ret
    }
