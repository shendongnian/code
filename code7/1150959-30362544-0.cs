      public class MyVendorLibWrapper
      {
        private readonly VendorLib vendorLib;
    
        public MyVendorLibWrapper()
        {
          this.vendorLib = new VendorLib();
        }
    
        public T GetValue<T>()
        {
          MethodInfo method = typeof(VendorLib)
            .GetMethod("GetVal", new Type[] { typeof(T).MakeByRefType() });
    
          object[] arguments = new object[] { default(T) };
          method.Invoke(this.vendorLib, arguments);
          return (T)arguments[0];
        }
      }
