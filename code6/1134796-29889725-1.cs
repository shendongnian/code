    private async void btn1_Click(object sender, EventArgs e)
    {
        await Task.Run(UpdateFirst);
        // Update UI here.
    }
    
    private async void btn2_Click(object sender, EventArgs e)
    {
        await Task.Run(UpdateSecond);
        // Update UI again.
    }
