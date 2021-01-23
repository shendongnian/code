    class B
    {
      protected void M() { }
    }
    class C : B
    {
      void X()
      {
        M(); // OK, same as this.M()
      }
      void Y(C otherC)
      {
        otherC.M(); // OK
      }
      void Z(B otherB)
      {
        otherB.M(); // compile-time error CS1540
      }
    }
