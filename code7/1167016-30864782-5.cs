    .method public hidebysig static void f () cil managed 
    {
      .maxstack 2
      .locals init
      (
      [0] class '<>f__AnonymousType0`2'<string, int64>
      )
      // Push the string "abc" onto the stack.
      ldstr "abc"
      // Push the number 2 onto the stack as an int32
      ldc.i4.2
      // Pop the top value from the stack, convert it to an int64 and push that onto the stack.
      conv.i8
      // Allocate a new object can call the <>f__AnonymousType0`2'<string, int64> constructor.
      // (This call will make use of the string and long because that's how the constructor is defined
      newobj instance void class '<>f__AnonymousType0`2'<string, int64>::.ctor(!0, !1)
      // Store the object in the locals array, and then take it out again.
      // (Yes, this is a waste of time, but it often isn't and so the compiler sometimes adds in these
      // stores).
      stloc.0
      ldloc.0
      // Call GetType() which will pop the current value off the stack (the object) and push on
      // The result of GetType()
      
      callvirt instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
      // Call WriteLine, which is a static method, so it doesn't need a System.Console item
      // on the stack, but which takes an object parameter from the stack.
      call void [mscorlib]System.Console::WriteLine(object)
      // Return
      ret
    }
