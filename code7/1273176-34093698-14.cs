    .method public hidebysig static void  Main() cil managed
    {
      .entrypoint
      .maxstack  1
      .locals init (int32 unassigned,
               int32 i,
               float64 d,
               float64 PI,
               string name)
      nop                           // Do Nothing (helps debugger to have some of these around).
      ldc.i4   4                    // Push number 4 on stack
      stloc    i                    // Pop value from stack, put in i (i = 4)
      ldloc    i                    // Push value in i on stack
      stloc    unassigned           // Pop value from stack, put in unassigned (unassigned = i)
      ldc.r8   12.34                // Push the 64-bit floating value 12.34 onto the stack
      stloc    d                    // Push the value on stack in d (d = 12.34)
      ldc.r8   3.1415926535897931   // Push the 64-bit floating value 3.1415926535897931 onto the stack.
      stloc PI                      // Pop the value from stack, put in PI (PI = 3.1415… which is the constant Math.PI)
      ldstr    "Ehsan"              // Push the string "Ehsan" on stack
      stloc    name                 // Pop the value from stack, put in name
      ret                           // return.
    }
