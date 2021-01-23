    private async void BtnClickEvent(object sender, RoutedEventArgs e)
    {
        bool success = await SomeMethodAsync();
        if (!success)
        {
            return;
        }
        //other code below... does not execute...
        DoSomethingElse();
    }
    private async Task<bool> SomeMethodAsync()
    {
        try
        {
            await Task.Run(() => _someObj.SomeMethod());
            return true;
        }
        catch (Exception ex)
        {
            string errMsg = string.Format("{0} {1}some unhandled error occurred in SomeMethod",
            ex.Message, Environment.NewLine);
            Log(errMsg);          
            return false;
        }
    }
