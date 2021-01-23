    #include "stdafx.h"
    using namespace System;
    using namespace System::IO;
    using namespace System::Collections;
    using namespace System::Runtime::Serialization::Formatters::Binary;
    using namespace System::Runtime::Serialization;
    
   
    
    [Serializable]
    public ref class Singleton
    {	
    public:
    	String^ str1;
    	String^ str2;
    	Int32 num;
    public:
    	// Private constructor allowing this type to construct the singleton.
    	Singleton()
    	{
    		// Do whatever is necessary to initialize the singleton.
    		str1 = "2222";
    		num =12345;
    	}
    public:static Singleton^ theInstance ;
    
    
    public: static property Singleton^ Instance
    		{ Singleton^ get()
    			{
    				if (theInstance == nullptr)
    					theInstance = gcnew Singleton();
    				return theInstance;
    			}
    		}
    };
    
    
    int main()
    {	
    	 FileStream^ fs = gcnew FileStream( "C:\\DataFile.dat",FileMode::OpenOrCreate );
    	Singleton^ a =  Singleton::Instance;
    	Console::WriteLine( "Reason: {0}",a->str1);
    	BinaryFormatter^ formatter = gcnew BinaryFormatter;	
    	formatter->Serialize(fs, a);
    	fs->Close(); 
    	
    
    	return 0;
    }
