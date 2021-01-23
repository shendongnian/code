    protected override Geometry DefiningGeometry
    {
        get { return _textGeometry ?? Geometry.Empty; }
    }
    
    private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((ExtendedTextBlock)d).CreateTextGeometry();
    }
    
    private void CreateTextGeometry()
    {
        var formattedText = new FormattedText(Text, Thread.CurrentThread.CurrentUICulture, FlowDirection.LeftToRight, new Typeface(FontFamily, FontStyle, FontWeight, FontStretch), FontSize, Brushes.Black);
        _textGeometry = formattedText.BuildGeometry(Origin);
    }
