    using System.Diagnostics;
    using System.IO;
    string[] definedPrograms = { "cheatengine.exe", "otherhacktool.exe" };
    
    void stopCheats()
    {
        Process[] processList = Process.GetProcesses();
        foreach (Process process in processList)
        {
            foreach (string definedProgram in definedPrograms)
            {
                if (Path.GetFileName(process.MainModule.FileName) == definedProgram)
                {
                    //Kill the other program
                    process.Kill();
                }
            }
        }
    }
