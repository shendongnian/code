            var p = new Process()
            {
                StartInfo = {
                CreateNoWindow = false,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                FileName = @"cmd.exe"}
            };
            p.OutputDataReceived += (sender, args1) => Console.WriteLine(args1.Data);
            p.ErrorDataReceived += (sender, args1) => Console.WriteLine(args1.Data);
            p.Start();
            p.BeginOutputReadLine();
            p.StandardInput.WriteLine("dir");
            p.StandardInput.WriteLine("cd e:");
            p.WaitForExit();
            Console.WriteLine("Done");
            Console.ReadLine();
