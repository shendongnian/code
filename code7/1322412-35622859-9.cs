    using System.Threading;
    bool installFinished = false;
    void Install_net45()
    {
        Process process = Process.Start(root + Installfolder + "dotnetFX45.exe", "/q");
        while (!process.WaitForExit(1000))
        {
        }
        installFinished = true;
        // Clean up
    }
    private async void InstallStart2()
    {
        if (Dot45 == "Yes")
        {
            this.Titel.Text = "The Knowhow Installer is installing:";
            this.Action.Text = "Microsoft .Net Framework 4.5";
            if (File.Exists(root + Installfolder + "dotnetFx45.exe"))
            {
                installFinished = false;
                Thread t = new Thread(Install_net45);
                t.Start();
				int k = -1;
				string[] dots = new string[] { "Installing.", "Installing..", "Installing..." };
				while (!installFinished)
				{
					Action.Text = dots[++k % 3];
					await Task.Delay(TimeSpan.FromSeconds(1.0));
				}
				Action.Text = "Finished";
                MessageBox.Show("Test");
            }
            else
            {
                this.TopMost = false;
                int num = (int)MessageBox.Show("dotnetFx45.exe not found", "Error");
            }
        }
    }
