        private void button1_Click(object sender, EventArgs e)
        {
            var consoleProcess = new Process
            {
                StartInfo =
                {
                    FileName =
                        @"background.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            consoleProcess.OutputDataReceived += ConsoleOutputHandler;
            consoleProcess.StartInfo.RedirectStandardInput = true;
            consoleProcess.Start();
            consoleProcess.BeginOutputReadLine();
        }
        private void ConsoleOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            // This is the method in your form that's 
            // going to display the line of output from the console.
            WriteToOutput(outLine.Data);
        }
