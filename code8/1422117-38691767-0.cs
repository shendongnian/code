     private void Form1_Load(object sender, EventArgs e)
            {
    
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Application.ExecutablePath;
                proc.Verb = "runas";
                Process.Start(proc);
                Application.Exit();  // Quit itself
            }
