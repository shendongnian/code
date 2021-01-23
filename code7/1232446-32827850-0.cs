    private async void WindowLoadedEx(object p)
    {
        DBMan();
        await LoadValuesAsync();
        Boot = false;
        MainMenuVisibility = true;
    }
    
    private async Task LoadValuesAsync()
    {
        var addHeroesTask = HeroesDBAddHeroesAsync();
        var addCommentsTask = HeroesDBAddCommentsAsync();
        
        // We cannot assign comments or IDs until these have been added
        await Task.WhenAll(addHeroesTask, addCommentsTask).ConfigureAwait(false);
        
        // TODO Should these both also be asynchronous?
        HeroesDBAssignComments();
        SetDBIDs();
    }
