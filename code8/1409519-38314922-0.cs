        Process myProcess = new Process();
        // assign start information to the process 
        myProcess.StartInfo = myProcessStartInfo;
        myProcess.RedirectStandardError = true;
        myProcess.RedirectStandardOutput = true;
        myProcess.Start();
        myProcess.BeginErrorReadLine();
        myProcess.BeginOutputReadLine();
        StreamReader myStreamReader = myProcess.StandardOutput;
        string myString = myStreamReader.ReadToEnd();
        Console.WriteLine(myString);
        // wait exit signal from the app we called and then close it. 
        myProcess.WaitForExit();
        myProcess.Close();
        Console.ReadLine();
