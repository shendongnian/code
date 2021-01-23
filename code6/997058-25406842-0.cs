    private async void SomeButtonClicked(object sender, EventArgs e)
    {
        try
        {
            DisableButton();
            await ALongRunningTask();
        }
        finally
        {         
            EnableButton();
        }
    }
