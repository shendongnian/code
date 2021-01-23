    Process p = new Process();
        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.Arguments = "/c " + "\"" + "set MYSPECIALENV=someContent & set & pause" + "\"";
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.UseShellExecute = true;
        Console.WriteLine("Starting process");
        p.Start();
        p.WaitForExit();
        ICollection envVarsSpawnedProcess = p.StartInfo.EnvironmentVariables.Keys;
        if (envVarsSpawnedProcess.Cast<string>().Contains("MYSPECIALENV"))
        {
            Console.WriteLine("Found! :)");
        }
        else
        {
            Console.WriteLine("Not found :(");
        }
       
