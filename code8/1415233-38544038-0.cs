     var process = new Process
            {
                StartInfo =
                          {
                              FileName = "netsh.exe",
                              Arguments = "wlan show interfaces ",
                              UseShellExecute = false,
                              RedirectStandardOutput = true,
                              CreateNoWindow = true
                          }
            };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            var lanProcess = new Process
            {
                StartInfo =
                          {
                              FileName = "netsh.exe",
                              Arguments = "interface show interface name=\"Ethernet\" ",
                              UseShellExecute = false,
                              RedirectStandardOutput = true,
                              CreateNoWindow = true
                          }
            };
            lanProcess.Start();
            var lanOutput = lanProcess.StandardOutput.ReadToEnd();
            var lanState = lanOutput.Split(new[] { Environment.NewLine },StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(l => l.Contains("Connect state"));
            var wlanState = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(l => l.Contains("State"));
            if (!wlanState.Contains("disconnected")&&lanState.Contains("Disconnected"))
                
            {
                Console.WriteLine("Wi-Fi");
            }
            else if(wlanState.Contains("disconnected") && !lanState.Contains("Disconnected"))
            {
                Console.WriteLine("Ethernet");
            }
            else if (!wlanState.Contains("disconnected") && !lanState.Contains("Disconnected"))
            {
                Console.WriteLine("Wi-Fi & Ethernet");
            }
            else
            {
                Console.WriteLine("Not connected");
            }
            Console.Read();
