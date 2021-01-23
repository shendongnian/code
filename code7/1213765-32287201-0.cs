    private void Form_Load(object sender, EventArgs e)
    {
        var file=System.IO.Path.Combine(Application.StartupPath, "YourFileName.wmv");
        if (!System.IO.File.Exists(file))
            System.IO.File.WriteAllBytes(file, Properties.Resources.YourFileName);
        this.axWindowsMediaPlayer1.URL = file;
        this.axWindowsMediaPlayer1.Ctlcontrols.play();
    }
