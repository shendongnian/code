       // Compile to "Example3.exe"
       using System;
       class Example3
       {
           public static int Main(string[] args) {
               Environment.ExitCode = 4;
               return 5;
           }
       }
       // Complile to "VsHostMock.exe"
       using System;
       class VsHostMock
       {
           public static void Main(string[] args) {
              var appDomain = AppDomain.CreateDomain("other");
              int returnCode = appDomain.ExecuteAssembly("Example3.exe");
              Console.WriteLine("ReturnCode: {0}", returnCode);
              Console.WriteLine("Environment.ExitCode: {0}", Environment.ExitCode);
           }
       }
