        private void doTask(object[] param)
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = param[0].ToString(),
                    //remove this line, it's not needed
                    //Arguments = param[1].ToString(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    //Add this line so you can write commands
                    RedirectStandardInput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            //now write your command with WriteLine so it mimics an enter press
            proc.StandardInput.WriteLine(param[1].ToString());
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                this.Invoke((MethodInvoker)delegate
                {
                    txtResponse.Text += line + Environment.NewLine;
                });
            }
            proc.WaitForExit();
        }
