      //Managed DLL
      // Class1.cs
      // A simple managed DLL that contains a method to add two numbers.
      using System;
      namespace ManagedDLL
      {
      	// Interface declaration.
          public interface ICalculator
          {
              int Add(int Number1, int Number2);
          };
          // Interface implementation.
      	public class ManagedClass:ICalculator
      	{
             public int Add(int Number1,int Number2)
                  {
                      return Number1+Number2;
                  }
      	}
      }
      //C++ Client
      // CPPClient.cpp: Defines the entry point for the console application.
      // C++ client that calls a managed DLL.
      #include "stdafx.h"
      #include "tchar.h"
      // Import the type library.
      #import "..\ManagedDLL\bin\Debug\ManagedDLL.tlb" raw_interfaces_only
      using namespace ManagedDLL;
      int _tmain(int argc, _TCHAR* argv[])
      {
          // Initialize COM.
          HRESULT hr = CoInitialize(NULL);
          // Create the interface pointer.
          ICalculatorPtr pICalc(__uuidof(ManagedClass));
          long lResult = 0;
          // Call the Add method.
          pICalc->Add(5, 10, &lResult);
          wprintf(L"The result is %d\n", lResult);
          // Uninitialize COM.
          CoUninitialize();
          return 0;
      }
