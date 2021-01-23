    public async void SupplierAutoSuggest_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var queryText = sender.Text;
            if(args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                if(!string.IsNullOrEmpty(queryText))
                {
                    //IEnumerable Returned
                    var suggestion = await App.Repository.Partners.GetAsync(queryText);
                    if (suggestion.Any())
                        sender.ItemsSource = suggestion;     
                }
            }
        }
