    public string SelectedFontFamily
    {
        get { return (string)GetValue(SelectedFontFamilyProperty); }
        set { SetValue(SelectedFontFamilyProperty, value); }
    }
    
    public static readonly DependencyProperty SelectedFontFamilyProperty = DependencyProperty.Register("SelectedFontFamily", typeof(string), typeof(YourUC), new PropertyMetadata(string.Empty));
