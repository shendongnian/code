     public void Foo(Bar arg)
     {
          //Conditional usage
          arg.IsNotNull();
          arg.IsNotTrue(t => t != null);
          //Unconditional fail
          throw CustomAssert.Fail();
     }
