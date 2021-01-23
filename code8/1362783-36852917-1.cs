       var process = new Process();
        if (workingDirectory != null) process.StartInfo.WorkingDirectory = workingDirectory;
        process.StartInfo.UseShellExecute = true;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.FileName = fileName;
        process.StartInfo.Arguments = arguments;
        process.Start();
