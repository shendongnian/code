    public static readonly DependencyProperty VideoTransformsNamesProperty = 
    DependencyProperty.Register("VideoTransformsNames", typeof(ObservableCollection<string>), typeof(UserControl2));
    
    public string VideoTransformsNames
    {
        get
        {
            return this.GetValue(VideoTransformsNamesProperty) as ObservableCollection<string>;
        }
        set
        {
            this.SetValue(VideoTransformsNamesProperty, value);
        }
    }
