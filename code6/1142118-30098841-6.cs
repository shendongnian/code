    <DataGrid SelectedIndex="{Binding SelectedIndex}" />
    private int _selectedIndex;
    public int SelectedIndex
    {
    get { return _selectedIndex; }
    set { _selectedIndex = value; NotifyPropertyChanged("SelectedIndex"); }
    }
