    private async void SomeButtonClicked(object sender, EventArgs e)
    {
        try
        {
            DisableButton();
            await ALongRunningTaskAsync();
        }
        finally
        {         
            EnableButton();
        }
    }
