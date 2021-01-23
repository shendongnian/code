        private void btnRun_Click(object sender, EventArgs e) {
            Task.Factory.StartNew(this.StdOutWorker);
        }
        private void StdOutWorker() {
            this.AppendLine("BEFORE OUTPUT DATA");
            // "CmdRandomGenerator.exe" will print random numbers to standard output in infinity loop
            ProcessStartInfo pi = new ProcessStartInfo("CmdRandomGenerator.exe") {
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            var proc = new Process{
                StartInfo = pi,
                EnableRaisingEvents = true
            };
            proc.Start();
            while (!proc.HasExited) {
                var line = proc.StandardOutput.ReadLine();
                this.AppendLine(line);
            }
            this.AppendLine("AFTER OUTPUT DATA");
        }
        private void AppendLine(string line) {
            Action act = () => {
                this.rtbOutput.AppendText(line + Environment.NewLine);
            };
            // UI objects must be accessed in UI thread
            this.BeginInvoke(act);
        }
