    // CCLI.h
    #pragma once
    using namespace System;
    namespace CCLI {
    
        public ref class A
        {
        public:
            int test(){return 0;}
        };
	
        public ref class B
        {
        public:
            static A^ a_Instance = gcnew A();
        };
    }
