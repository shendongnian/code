    string account = textBox1.Text;
    string password = textBox2.Text;
    string command = "cmd.exe";
    string argument = String.Format("/c net user {0} {1}", account, password);
    using (Process p = new Process())
    {
        p.StartInfo.FileName = command;
        p.StartInfo.Arguments = argument;
        p.Start();
    }
