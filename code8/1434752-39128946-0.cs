    This following one worked for me! 
    using System.Diagnostics;
    public void ExecuteBatFile()
            {
                Process proc = null;
                string _batDir = string.Format(@"C:\"); //File path Location
                proc = new Process();
                proc.StartInfo.WorkingDirectory = _batDir;
                proc.StartInfo.FileName = "myfile.bat"; // Batch File name
                proc.Start();
                proc.WaitForExit();
                proc.Close();
            }
