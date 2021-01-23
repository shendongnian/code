    private void timer1_Tick(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
            using (SshClient cSSH = new SshClient("ip", 22, "root", "pass")
            {
                cSSH.Connect();
                SshCommand x = cSSH.RunCommand("ssh command");
            }
        });
    }
