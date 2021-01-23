    private List<string> suggestions;
    public ObservableCollection<string> autoList { get; set; }
    private void searchTextChanged(object sender, TextChangedEventArgs e)
    {
        string text = quickSearchText.Text; //Get typing text.
        var suggestedList = suggestions.Where(suggestion => !string.IsNullOrEmpty(text) && suggestion.StartsWith(text)); //Get possible suggestions
        autoList.Clear();
        foreach (var item in suggestedList)
        {
            autoList.Add(item);
        }
        // Show all, if text is empty.
        if (string.IsNullOrEmpty(text) && autoList.Count == 0)
        {
            foreach (var item in suggestions)
            {
                autoList.Add(item);
            }
        }
        quickSearchText.IsDropDownOpen = autoList.Count != 0; //Open if any.
    }
