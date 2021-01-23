    private async void SearchBox_SuggestionsRequested(SearchBox sender,
    SearchBoxSuggestionsRequestedEventArgs args){
    if (string.IsNullOrEmpty(args.QueryText))
    {
        return;
    }
    var collection = args.Request.SearchSuggestionCollection;
    if(oldquery != args.QueryText)
    {
        //ADD THIS LINE
        var deferral = args.Request.GetDeferral();
        var listOfBanks = await addFIPageViewModel.GetBanksOnQuery();
        foreach (Institution insti in listOfBanks)
        {
            collection.AppendQuerySuggestion(insti.name);
        }
        //ADD THIS LINE
        deferral.Complete();
        oldquery = args.QueryText;
    }}
