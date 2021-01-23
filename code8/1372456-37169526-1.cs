    using System;
    using System.Diagnostics;
    namespace CaptureProcessStdOutErr
    {
      public class Program
      {
        public static void Main(string[] args)
        {
          var startInfo = new ProcessStartInfo("java", "JavaApplication") // proper path to java, main java class, classpath, jvm parameters, etc must be specified or use java -jar jarName.jar if packaged into a single jar
          {
            RedirectStandardError  = true,
            RedirectStandardOutput = true,
            UseShellExecute        = false
          };
          var process = Process.Start(startInfo);
          process.WaitForExit();
          Console.WriteLine("Captured stderr from java process:");
          Console.WriteLine(process.StandardError.ReadToEnd());
          Console.WriteLine();
          Console.WriteLine("Captured stdout from java process");
          Console.WriteLine(process.StandardOutput.ReadToEnd());
        }
      }
    }
