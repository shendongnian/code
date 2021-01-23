            static void ExecuteCommandSync(object command)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo(@"C:/Windows/System32/blat.exe", "-server 127.0.0.1:1099 -subject Hello -to myname@gmail.com -body theBody -p gmailsmtp -from myname@gmail.com");
                System.Diagnostics.Process process;
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.RedirectStandardError = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                process = System.Diagnostics.Process.Start(procStartInfo);
                process.WaitForExit();
                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                var exitCode = process.ExitCode;
                Console.WriteLine(error);
                process.Close();
            }
            catch (Exception objException)
            {
                // to be logged
            }
        }
