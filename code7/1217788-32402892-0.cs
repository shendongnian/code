    class Foo {
      SomeClassType sct;
      SomeOtherClass soc;
      public Foo(SomeClassType xSct, SomeOtherClass xSoc) {
        // Note: No initializer list, we have to do those assignments manually
        sct = xSct;
        soc = xSoc;
      }
    }
