        public string RunPowershell(string param1)
        {
            var outputString = "";
            var startInfo = new ProcessStartInfo
            {
                FileName = @"powershell.exe",
                Arguments = "C:\\path\\to\\script.ps1" + " -param1  " + param1,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using (var process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();
                var output = process.StandardOutput.ReadToEnd();
                var errors = process.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(output))
                {
                    outputString = output;
                }
                if (!string.IsNullOrEmpty(errors))
                {
                    Console.WriteLine($"Error: {errors}");
                }
            }
            return outputString;
        }
