    using System.Diagnostics;
    private async void pictureBox1_Click(object sender, EventArgs e)
    {
        // start the progress, don't wait until finished yet:
        var process1 = Process.Start("c:/installer.exe").WaitForExit();
        while (!process1.HasExited)
        {
            // process not finished yet, increase progress bar and wait a while
            this.progressBar1.Step();
            await Task.Delay(TimeSpan.FromSeconds(0.2);
        }
        // if here, process1 has finished: we are halfway:
        progressBar1.Value = (progressbar1.Minimum + progressBar1.Maximum)/2;
        // start process 2
        var process2 = Process.Start("c:/installer2.exe");
         while (!process2.HasExited)
        {
            // process not finished yet, increase progress bar and wait a while
            this.progressBar1.Step();
            await Task.Delay(TimeSpan.FromSeconds(0.2);
        }
        // both processes finished; full progressbar:
        this.progressBar1.Value = this.progressBar1.Maximum;
    }
