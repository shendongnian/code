    NativeLayer::NativeLayerData* native_data;
    
    
    public ref class Test1Implementer : ITest1
    {
         virtual bool TestConnect()
         {
            bool success = native_data->Connect();
            return success;
         }
    };
    
    public ref class Test2Implementer : ITest2
    {
         virtual bool TestDisconnect()
         {
            bool success = native_data->Disconnect();
            return success;
         }
    };
