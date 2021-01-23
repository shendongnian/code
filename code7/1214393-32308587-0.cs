    using System;
    using System.Runtime.InteropServices;
    
     class BeepSample
     {
         [DllImport("kernel32.dll", SetLastError=true)]
         [return: MarshalAs(UnmanagedType.Bool)]
         static extern bool Beep(uint dwFreq, uint dwDuration);
    
         static void Main()
         {
             Console.WriteLine("Testing PC speaker...");
             var success = Beep(200, 5);
             Console.WriteLine("Testing complete. " + success);
         }
