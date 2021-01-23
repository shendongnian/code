      var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            StringBuilder sb = new StringBuilder();
            var outStream = proc.StandardOutput;
            var inStream = proc.StandardInput;
            inStream.WriteLine("mkdir test");
            Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(outStream.ReadLine());
                }
            });
            Console.WriteLine("dir");
            inStream.WriteLine("dir");
            Console.WriteLine("mkdir test");
            inStream.WriteLine("mkdir test");
            Console.WriteLine("dir");
            inStream.WriteLine("dir");
            Console.ReadLine();
        }
