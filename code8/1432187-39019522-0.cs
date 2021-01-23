    #pragma once
    using namespace System;
    
    namespace Blah
    {
    public value struct HoopieAdapter : public IHoopie<int> {
        public: virtual void DoSomething(int% source) {}
    };
    
    public value struct TestStruct : public IHoopie<TestStruct> 
    {
    public:
        double X;
        double Y;
        double Z;
    
        virtual void DoSomething(TestStruct% source)
        {
            X = 1;
            Y = 2;
            Z = 3;
        };
    };
    }
