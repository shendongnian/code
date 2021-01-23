    public ref class TestsImplementer : ITests 
    {
    private:
        NativeLayer::NativeLayerData* native_data;
    
    public:
          TestsImplementer()
          {
             native_data = new NativeLayer::NativeLayerData();
          }
    
          ref class Test1Implementer : ITest1
          {
             virtual bool TestConnect(TestsImplementer^ tests)
             {
                bool success = tests->native_data->Connect();
                return success;
             }
          };
    
          ref class Test2Implementer : ITest2
          {
             virtual bool TestDisconnect(TestsImplementer^ tests)
             {
                bool success = tests->native_data->Disconnect();
                return success;
             }
          };
    };
