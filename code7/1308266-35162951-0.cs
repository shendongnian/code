    public TestClass()
    {
        _viewModel.PropertyChanged += OnPropertyChanged;
    }
    
    private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName == "Foo")
        {
            _textBlock.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }
    }
