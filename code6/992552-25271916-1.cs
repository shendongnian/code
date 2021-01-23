    private async Task ExecuteButton(Button button, string toolName)
    {
         button.Text = "Starting";
         button.Enabled = false;
         await Task.Run(() => toolStarter.startTool(toolName));
         button.Text = "Autoruns";
         button.Enabled = true;  
    }
    private async void button1Click(object sender, EventArgs e)
    {
         await ExecuteButton(button1, "button1");
         // Do any other specific stuff for after here
    }
    // Use for other buttons as needed
    private async void button2Click(object sender, EventArgs e)
    {
         await ExecuteButton(button2, "button2");
    }
