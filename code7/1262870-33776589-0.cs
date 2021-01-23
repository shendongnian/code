    bool isBusyProcessing = false;
    private async void textBox1_TextChanged(object sender, EventArgs e)
    {
        while (isBusyProcessing)
            await Task.Delay(50);
        try
        {
            isBusyProcessing = true;
            // Do your intensive work
        }
        finally
        {
            isBusyProcessing = false;
        }
    }
