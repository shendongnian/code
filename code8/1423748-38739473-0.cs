    // filename.h
    #pragma once
    using namespace System;
    namespace YourNampespace
    {
      public ref class YourClass abstract sealed
      {
        //int __stdcall OpenRTSP(char url, char progname);
        //You want to convert this to managed, buf if you return "int", with "char" params,
        // it won't be a problem
      }
    }
