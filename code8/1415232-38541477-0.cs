     var process = new Process
            {
                StartInfo =
                          {
                              FileName = "netsh.exe",
                              Arguments = "wlan show interfaces",
                              UseShellExecute = false,
                              RedirectStandardOutput = true,
                              CreateNoWindow = true
                          }
            };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            var state = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(l => l.Contains("State"));
            if (!state.Contains("disconnected"))
            {
                Console.WriteLine("Wi-Fi");
            }
            else
            {
                Console.WriteLine("Ethernet");
            }
            Console.Read();
