    using namespace System;
    using namespace System::Reflection;
    Assembly^ MyResolveEventHandler(Object^ sender, ResolveEventArgs^ args)
    {
        if (args->Name == "CodeToCall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
            return Assembly::LoadFrom("C:\\Program Files (x86)\\Sigma\\CodeToCall.dll");
        else
            return nullptr;
    }
    void UseClass1()
    {
        auto obj = gcnew CodeToCall::Class1;
        obj->Some();
    }
    int main(array<System::String ^> ^args)
    {
        AppDomain::CurrentDomain->AssemblyResolve += gcnew ResolveEventHandler(MyResolveEventHandler);
        // You can't directly use Class1 in the same method/function
        // that you use to subscribe to AssemblyResolve.
        UseClass1();
        Console::ReadKey();
        return 0;
    }
