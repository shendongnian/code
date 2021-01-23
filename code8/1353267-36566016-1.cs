            Process p1 = new Process();
            ProcessStartInfo psi1 = new ProcessStartInfo("powershell",
                "Get-ItemProperty HKLM:\\Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\* | Select-Object DisplayName")
            {
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            p1.StartInfo = psi1;
            p1.StartInfo.UseShellExecute = false;
            p1.StartInfo.Verb = "runas";
            p1.Start();
            string output = p1.StandardOutput.ReadToEnd();
            var lines = output.Split('\r', '\n');
            foreach (var line in lines)
            {
                if (!String.IsNullOrWhiteSpace(printline))
                {
                    Console.WriteLine(printline.Trim());
                }
            }
           
            p1.WaitForExit(400);
