    private void chkModules_Checked(object sender, RoutedEventArgs e)
    {
            IsChecked = IssuesTypes.Any(it => it.IsChecked);
    }
    private bool isChecked;
    public bool IsChecked
    {
        get { return isChecked; }
        set
        {
            if (isChecked != value)
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
    }
