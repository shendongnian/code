    protected async void FindGames_Click(object sender, EventArgs e)
    {
        try
        {
            await RunAsync();
        }
        catch (Exception err)
        {
            lbl_results.Text = err.Message;
        }
        
    }
