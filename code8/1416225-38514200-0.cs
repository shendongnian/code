    public static void Main (string[] args)
    {
      SampleClass objectC; // variable declaration, initialized with default of type
      objectC.PrintFunc(); //Use of function of object just initialized
    }
    struct SampleClass // note: "struct" in C# matches C++ "class"/"struct"
    {
         public void PrintFunc()
        {
          Console.WriteLine("Hello World");
        }
    }
