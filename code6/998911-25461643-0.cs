    private void button_Click(object sender, EventArgs e) {
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
        string output;
        // read output one line at the time. If the output is null, the application quit
        while ((output = p.StandardOutput.ReadLine()) != null) {
            textBox1.Text += output + Environment.NewLine;
            Application.DoEvents();
        }
    
        p.WaitForExit();
    }
