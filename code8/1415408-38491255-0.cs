            var p = new Process()
            {
                StartInfo = {
        CreateNoWindow = true,
        UseShellExecute = false,
        //RedirectStandardError = true,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        FileName = @"cmd.exe",
            }
            };
            p.Start();
            p.StandardInput.WriteLine("dir");
            p.StandardInput.Flush();
            p.StandardInput.Close();
            // Test by reading stdout and sending to our program's Console window
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();
            // Pause so we can look at the console window
            Console.ReadLine(); 
        }
