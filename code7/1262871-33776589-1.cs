    bool isBusyProcessing = false;
    private async void textBox1_TextChanged(object sender, EventArgs e)
    {
        while (isBusyProcessing)
            await Task.Delay(50);
        try
        {
            isBusyProcessing = true;
            await Task.Run(() =>
            {
                // Do your intensive work in a Task so your UI doesn't hang
            });
        }
        finally
        {
            isBusyProcessing = false;
        }
    }
