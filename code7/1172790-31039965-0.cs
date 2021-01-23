    private async Task sshAllStdOut(CancellationToken token, string ipaddress, string ldapUsername, string ldapPassword, string command) // work in progress
        {
            SshClient client = new SshClient(ipaddress, 22, ldapUsername, ldapPassword);
            client.Connect();
            var stream = client.CreateShellStream("dumb", 120, 24, 360, 600, 1024);
            
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                while (stream.Length == 0)
                {
                    Thread.Sleep(1000);
                }
           
                WriteStream(command, writer, stream);
                Thread.Sleep(1000);
                WriteStream("\n", writer, stream);
          
            while (client.IsConnected)
            {
                string line = reader.ReadLine();
                if (line != null)
                {
                    updateGUI(line, pingCheckStdOut);
                    Thread.Sleep(100);
                }
              if (line == "server_name:~ $ ")
                {
                    client.Disconnect();
                    
                }
            }
           
            
        }
       // this is to pull the data from the 2nd thread back into the main thread
        delegate void SetTextCallback(string output, RichTextBox guiElement);
        public void updateGUI(string input, RichTextBox guiElement)
        {
            string output = input;
            
            if (this.InvokeRequired)
            {
                // It's on a different thread, so use Invoke.
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke
                    (d, new object[] { output, guiElement });
            }
            else
            {
                // Else it's on the same thread, no need for Invoke
                guiElement.Text = output;
            }
        }
        // This method is passed in to the SetTextCallBack delegate
        // to set the Text property of textBox1.
        public void SetText(string output, RichTextBox guiElement)
        {
            guiElement.AppendText(output + "\n");
            guiElement.ScrollToCaret();
            
           
        }
