    using System;
    using System.Runtime.InteropServices;
    namespace Dietrich.Math
    {
      [ComVisible(true), Guid("B452A43E-7D62-4F11-907A-E2132655BF97")]
      [InterfaceType(ComInterfaceType.InterfaceIsDual)]
      public interface IArithmetic
      {
        int Add(int a, int b);
      }
      [ComVisible(true), Guid("17A76BDC-55B7-4647-9465-3D7D088FA932")]
      [ProgId("SimpleMath.Whatever")]
      [ClassInterface(ClassInterfaceType.None)]
      public class Arithmetic : IArithmetic
      {
        public int Add(int a, int b) { return a + b; }
      }
    }
