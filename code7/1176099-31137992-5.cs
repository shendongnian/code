    .method public hidebysig instance void myMethod () cil managed 
    {
      .locals init ([0] class Temp.Program/Customer)       // Set-up space for a reference to a Customer
    
      nop                                                  // Do nothing.
      newobj instance void SomeNamespace/Customer::.ctor() // Call Customer constructor (results in Customer on the stack)
      stloc.0                                              // Store the customer in the frist slot in locals
      ret                                                  // Return
    }
    
    .method public hidebysig instance void myMethod () cil managed 
    {
      newobj instance void SomeNamespace/Customer::.ctor() // Call Customer constructor (results in Customer on the stack)
      pop                                                  // Remove value from stack
      ret                                                  // Return
    }
