    public static ObservableCollection<ReisItem> Reizen { get; set; }
    public async Task getReizen()
    {
        string currentlyLoggedInUser = App.MobileService.CurrentUser.UserId;
        var result = await App.MobileService.GetTable<ReisItem>();
        Reizen = result.Where(c => c.userID == currentlyLoggedInUser).ToCollectionAsync();
    }
