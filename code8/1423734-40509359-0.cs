            var psi = new ProcessStartInfo
            {
                FileName = Path.Combine(solutionRootPath, @"packages\OwinHost.3.0.1\tools\\OwinHost.exe"),
                WorkingDirectory = packageFolder,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false
            };
            var process = Process.Start(psi);
            process.ErrorDataReceived += (sender, args) =>
            {
                Console.WriteLine(args.Data);
            };
            process.OutputDataReceived += (sender, args) =>
            {
                Console.WriteLine(args.Data);
            };
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
