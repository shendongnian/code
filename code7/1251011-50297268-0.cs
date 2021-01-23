    using System;
    using System.Diagnostics;
    
    namespace CallMultipleMethods2
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    // Start first application.
                    Process firstProc = new Process();
                    firstProc.StartInfo.FileName = "c:/MyPrograms/program1.exe";
                    firstProc.EnableRaisingEvents = true;
    
                    firstProc.Start();
    
                    firstProc.WaitForExit();
    
                    //You may want to perform different actions depending on the exit code.
                    Console.WriteLine("First process completed: " + firstProc.ExitCode);
                    // End of first application
    
                    // Start second application
                    Process secondProc = new Process();
                    secondProc.StartInfo.FileName = "c:/MyPrograms/program2.exe";
                    secondProc.Start();
    
                    secondProc.WaitForExit();
    
                    Console.WriteLine("Second process completed: " + secondProc.ExitCode);
                    // End of second application
    
                    // Start third application
                    Process thirdProc = new Process();
                    thirdProc.StartInfo.FileName = "c:/MyPrograms/program3.exe";
                    thirdProc.Start();
    
                    thirdProc.WaitForExit();
    
                    Console.WriteLine("Third process completed: " + thirdProc.ExitCode);
                    // End of third application
    
                    // Start fourth application
                    Process fourthProc = new Process();
                    fourthProc.StartInfo.FileName = "c:/MyPrograms/program4.exe";
                    fourthProc.EnableRaisingEvents = true;
    
                    fourthProc.Start();
    
                    fourthProc.WaitForExit();
    
                    Console.WriteLine("Fourth process completed: " + fourthProc.ExitCode);
                    // End of fourth application
                }
    
                // catch on error
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred!!!: " + ex.Message);
                    return;
                }
            }
        }
    }
