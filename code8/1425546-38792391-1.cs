    newobj      List<System.Int32>..ctor // Create list object.
    stloc.0                              // Store list object as local variable "0".
    ldloc.0                              // Load local variable "0" (the list object) and 
                                         // push it onto the stack.
    ldc.i4.1                             // Load the 4-byte integer constant "1" and push it
                                         // onto the stack.
    callvirt    List<System.Int32>.Add   // Call "Add" (uses and pops the last two values from
                                         // the stack).
    ldloc.0                              // Push list onto stack again.
    ldc.i4.2                             // Load and push "2".
    callvirt    List<System.Int32>.Add   // Call "Add".
