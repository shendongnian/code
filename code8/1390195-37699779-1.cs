    public async void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false; // disable button to not get called twice
      
        await Task.Run(() =>
        {
            // process your files
        }
        button1.Enabled = true; // re-enable button
    }
