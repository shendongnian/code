    Process process;
    bool installFinished = false;
    async void Animate()
    {
        int k = -1;
        string[] dots = new string[] { "Installing.", "Installing..", "Installing..." };
        while (!installFinished)
        {
            Action.Text = dots[++k % 3];
            await Task.Delay(TimeSpan.FromSeconds(1.0));
        }
        Action.Text = "Finished";
    }
    void netProcess_Exited(object sender, EventArgs e)
    {
        installFinished = true;
        // Clean up
    }
    private void InstallStart2()
    {
        if (Dot45 == "Yes")
        {
            this.Titel.Text = "The Knowhow Installer is installing:";
            this.Action.Text = "Microsoft .Net Framework 4.5";
            if (File.Exists(root + Installfolder + "dotnetFx45.exe"))
            {
                installFinished = false;
                Animate();
                process = new Process();
                process.StartInfo.FileName = root + Installfolder + "dotnetFX45.exe";
                process.StartInfo.Arguments = "/q";
                process.Exited += netProcess_Exited;
                process.Start();
            }
            else
            {
                this.TopMost = false;
                int num = (int)MessageBox.Show("dotnetFx45.exe not found", "Error");
            }
        }
    }
