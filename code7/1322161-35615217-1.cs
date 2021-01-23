    public ref class TestTempFactory
    {
      public:
        generic<typename T> static ITestTemp<T>^ Create()
        {
          if (T::typeid == String::typeid)
          { return (ITestTemp<T>^) gcnew TestTemp<String>(); }
          //more cases as needed...
        }
    }
