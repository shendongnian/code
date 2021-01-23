    private async void button1Click(object sender, EventArgs e)
    {
         button1.Text = "Starting";
         button1.Enabled = false;
         await Task.Run(() => toolStarter.startTool("button1"));
         button1.Text = "Autoruns";
         button1.Enabled = true;  
    }
