    .class interface public abstract auto ansi ITest
    {
      .method public hidebysig newslot abstract virtual 
              instance void  TestMethod() cil managed
      {
      } // end of method ITest::TestMethod
    
    } // end of class ITest
    
    .class public auto ansi beforefieldinit Test
           extends [mscorlib]System.Object
           implements ITest
    {
      .method private hidebysig newslot virtual final 
              instance void  ITest.TestMethod() cil managed
      {
        .override ITest::TestMethod
        // Code size       11 (0xb)
        .maxstack  8
        IL_0000:  ldstr      "I am Test"
        IL_0005:  call       void [mscorlib]System.Console::WriteLine(string)
        IL_000a:  ret
      } // end of method Test::ITest.TestMethod
    
      .method private hidebysig instance void 
              TestMethod() cil managed
      {
        // Code size       11 (0xb)
        .maxstack  8
        IL_0000:  ldstr      "I am other test"
        IL_0005:  call       void [mscorlib]System.Console::WriteLine(string)
        IL_000a:  ret
      } // end of method Test::TestMethod
