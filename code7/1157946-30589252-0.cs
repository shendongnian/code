    void UpdateProgress()
    {
        if (InvokeRequired)
        {
            MethodInvoker method = new MethodInvoker(UpdateProgress);
            Invoke(method);
            return;
        }
            if(checkbox1.Checked)
            {
                for (int k = 0; k < array.Length; k++)
                {
                  
    this.Invoke((MethodInvoker)delegate {
                    this.lbl_CurrentProject.Text = "Current Project: " + @"  " + array[k];
                    progressBar1.Value = int.Parse(((k * 100) / array.Length).ToString());
                    progressBar1.CreateGraphics().DrawString(((k * 100) / array.Length).ToString() + "%", new Font("Arial", (float)10.25, FontStyle.Bold), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                    System.Threading.Thread.Sleep(100);
                    progressBar1.PerformStep();
                    progressBar1.Refresh();
    });
                }
    }
