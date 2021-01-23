    public static readonly DependencyProperty ButtonsBacklitListProperty =
        DependencyProperty.Register("ButtonsBacklitList", typeof(ObservableCollection<bool>), typeof(ControlButtons),
            new FrameworkPropertyMetadata(new ObservableCollection<bool>(), onBBLCallBack));
    public ObservableCollection<bool> ButtonsBacklitList
    {
        get { return (ObservableCollection<bool>)GetValue(ButtonsBacklitListProperty); }
        set { SetValue(ButtonsBacklitListProperty, value); }
    }
    // Not sure why you want to capture changes, I hope it's not for binding
    // But I'm copying it anyway
    private static void onBBLCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        ControlButtons h = sender as ControlButtons;
        if (h != null)
        {
            h.onBBLChanged();
        }
    }
    // This looks super suspicious because all you did is to trigger INotifyPropertyChanged's handler!
    // I hope somewhere in your code you actually need to manually handle this change event...
    protected virtual void onBBLChanged()
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs("ButtonsBacklitList"));
        Console.WriteLine("UPDATED");
    }
