    clientProcess.StartInfo.FileName = "java.exe";
    clientProcess.StartInfo.Arguments = JavaArgument;
    clientProcess.StartInfo.CreateNoWindow = true;
    clientProcess.StartInfo.UseShellExecute = false;
    clientProcess.StartInfo.WorkingDirectory = HttpRuntime.AppDomainAppPath;
    clientProcess.StartInfo.RedirectStandardError = true; //add this line
    
    clientProcess.Start();
    string CompilerErrors = clientProcess.StandardError.ReadToEnd(); //add this line
    clientProcess.WaitForExit();
    
    return System.IO.File.ReadAllText(FileNameOutput); //add breakpoint here
