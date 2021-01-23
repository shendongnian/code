     public void Foo(Bar arg)
     {
          //Conditional usage
          arg.IsNotNull();
          arg.IsNotTrue(t => t != null);
          arg.IsInRange(0, 2);
          //Unconditional fail
          throw CustomAssert.Fail<NotSupportedException>();
     }
