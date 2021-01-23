    #pragma once
    #include "conversion.h"
    
    using namespace System;
    using namespace System::Collections::Generic;
    using namespace System::Runtime::InteropServices;
    // forward declaration
    class PureQt;
    
    namespace ManagedCppQtSpace {
        delegate void someFuncWasCalled(String^);
    
        public ref class ManagedCppQt
        {
        public:    
            ManagedCppQt(String^ name);
            ~ManagedCppQt();
    
            event someFuncWasCalled ^ someFuncCalled;
    
            void someFunc(String^ string);
    
            String^ getSomeString();
    
            void signalCallback(QString str);
    
        private:
            PureQt * pureQtObject;
        };
    }
