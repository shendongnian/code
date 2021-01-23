    private bool _stop = false;
    private void cancelButton_Click(object sender, EventArgs e)
    {
        _stop = true;
    }
    private async void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false; // disable button to not get called twice
        _stop = false;
     
        await Task.Run(() =>
        {
            // process your files
            foreach(var file in files)
            { 
                if (_stop) return;
                // process file
            }
        }
        button1.Enabled = true; // re-enable button
    }
