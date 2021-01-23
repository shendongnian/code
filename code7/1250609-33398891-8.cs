    public RelayCommand SendClicked
    {
        get
        {
            return new RelayCommand(() =>
            {
                _inlineList = new List<Inline>();
                InlineList.Add(new Run("This is some bold text") { FontWeight = FontWeights.Bold });
                InlineList.Add(new Run("Some more text"));
                InlineList.Add(new Run("This is some text") { TextDecorations = TextDecorations.Underline });
                RaisePropertyChanged("InlineList");
            });
        }
    }
