    private void timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            Task.Factory.StartNew(() =>
            {
                SshClient cSSH = new SshClient("ip", 22, "root", "pass");
                cSSH.Connect();
                SshCommand x = cSSH.RunCommand("ssh command");
                cSSH.Disconnect();
                cSSH.Dispose();
            });
        }
        catch (Exception error)
        {
            MessageBox.Show("Error:" + error);
        }
    }
