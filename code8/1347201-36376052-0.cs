    private SshExec shell;
    public void button1_Click(object sender, EventArgs e)
    {
          shell = new SshExec("hostname", "username", "password");
          shell.Connect();
    }
    
    public void button2_Click(object sender, EventArgs e)
    {
          shell.RunCommand("ls");
    }
