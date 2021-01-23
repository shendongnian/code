    class Program {
        static void GenerateSecEditOutput(string tempFile) {
            var p = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\secedit.exe"),
                    Arguments = String.Format(@"/export /cfg ""{0}"" /quiet", tempFile),
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };
            p.Start();
            p.WaitForExit();
        }
    
        //... Main goes here
    }
