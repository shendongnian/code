    class MyClassULong : IMyClass
    {
        void Caller()
        {
            ulong val = 0;
            this.GetValue(ref val);
        }
    
        void GetValue(ulong val)
        {
            VendorLib v = new VendorLib();
            v.GetVal(ref val);
        }
    
    }
    
    class MyClassBool : IMyClass
    {
        void Caller()
        {
            bool val = false;
            this.GetValue(ref val);
        }
    
        void GetValue(bool val)
        {
            VendorLib v = new VendorLib();
            v.GetVal(ref val);
        }
    
    }
    
    public interface IMyClass
    {
        void Caller();
    }
