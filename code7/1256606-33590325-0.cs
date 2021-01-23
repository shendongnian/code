    var psi = new ProcessStartInfo(@"c:\temp\mycommand.exe", String.Format(" \"{0}\" \"{1}\" \"{2}\"", sourceDoc, dataSource, outputFile))
            {
                WorkingDirectory = Environment.CurrentDirectory,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = false
            };
            using (var process = new Process { StartInfo = psi })
            {
                process.Start();
                 process.BeginErrorReadLine();
                  process.BeginOutputReadLine();
                // wait for the process to exit
                process.WaitForExit();
           
                if (process.ExitCode != 0)
                {
                   
                }
            }
        }
