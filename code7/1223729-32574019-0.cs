        private void btnLaunch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = GetJavaInstallationPath();
            startInfo.Arguments = "-Djava.library.path=\"lib\\natives-win\" -jar SecondDimension.jar " + chbWindowed.Checked.ToString();
            process.StartInfo = startInfo;
            process.Start();
            this.Visible = false;
            process.WaitForExit();
            Application.Exit();
        }
