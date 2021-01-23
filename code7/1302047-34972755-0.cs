    public ChooseStoryToPlay_ViewModel ViewModel
    {
        get { return (ChooseStoryToPlay_ViewModel)GetValue(ViewModelProperty); }
        set { SetValue(ViewModelProperty, value); }
    }
    public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register("ViewModel", typeof(ChooseStoryToPlay_ViewModel), typeof(MainPage), new PropertyMetadata(0));
