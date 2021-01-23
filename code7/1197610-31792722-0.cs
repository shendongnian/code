    protected async Task SyncAll()
    {
        var ProgressAlert = await this.ShowProgressAsync("Please wait...", "Sync....");  //show message
        ProgressAlert.SetIndeterminate(); //Infinite
    
        try
        {
           await Task.Run(() => MyMagicCode());
    
           //show info
           await ProgressAlert.CloseAsync();
           await this.ShowMessageAsync("End","Succes!");
        }
        catch 
        {
            await ProgressAlert.CloseAsync();
            await this.ShowMessageAsync("Error!", "Contact with support");
        }
    
    }
