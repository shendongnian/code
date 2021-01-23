    public async override Task<bool> SyncNavigationMethod()
    {
        await AsyncShowDialog();
        return true;
    }
    
    public async Task AsyncShowDialog()
    {
        await SomeOperation();
    }
