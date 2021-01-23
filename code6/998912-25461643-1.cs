    private void button_Click(object sender, EventArgs e) {
        new Thread(() => {
    
            Process p = new Process();
            p.StartInfo.FileName = "ping.exe";
    
            // you can put together any arguments you'd like in the string format call
            // for the moment only the text from hostBox is needed
            // for instance string.Format("{0} -t", hostBox.Text); if you want to ping indefinately
            p.StartInfo.Arguments = string.Format("{0}", hostBox.Text);
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
    
            p.Start();
            string line;
            // read output one line at the time. If the output is null, the application quit
            while ((line = p.StandardOutput.ReadLine()) != null) {
                string output1 = line;
                textBox1.Invoke(new Action(() => {
                    textBox1.Text += output1 + Environment.NewLine;
                }));
            }
    
            p.WaitForExit();
        }).Start();
    }
