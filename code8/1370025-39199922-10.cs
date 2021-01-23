    using System;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    
    namespace AutomationAddin
    {
    
      // Replace the Guid below with your own guid that
      // you generate using Create GUID from the Tools menu
      [Guid("A33BF1F2-483F-48F9-8A2D-4DA68C53C13B")] 
      [ClassInterface(ClassInterfaceType.AutoDual)]
      [ComVisible(true)]
      public class MyFunctions
      {
        public MyFunctions()
        {
    
        }
    
        public double MultiplyNTimes(double number1, double number2, double timesToMultiply)
        {
          double result = number1;
          for (double i = 0; i < timesToMultiply; i++)
          {
            result = result * number2;
          }
          return result;
        }
    
        [ComRegisterFunctionAttribute]
        public static void RegisterFunction(Type type)
        {
          Registry.ClassesRoot.CreateSubKey(GetSubKeyName(type, "Programmable"));
          RegistryKey key = Registry.ClassesRoot.OpenSubKey(GetSubKeyName(type, "InprocServer32"), true);
          key.SetValue("", System.Environment.SystemDirectory + @"\mscoree.dll",RegistryValueKind.String);
        }
    
        [ComUnregisterFunctionAttribute]
        public static void UnregisterFunction(Type type)
        {
          Registry.ClassesRoot.DeleteSubKey(GetSubKeyName(type, "Programmable"), false);
        }
    
        private static string GetSubKeyName(Type type, string subKeyName)
        {
          System.Text.StringBuilder s = new System.Text.StringBuilder();
          s.Append(@"CLSID\{");
          s.Append(type.GUID.ToString().ToUpper());
          s.Append(@"}\");
          s.Append(subKeyName);
          return s.ToString();
        }  
      }
    }
