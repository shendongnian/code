    <DataGrid SelectedItem="{Binding SelectedRow}" />
    private DataRow _selectedRow;
    public DataRow SelectedRow
    {
    get { return _selectedRow; }
    set { _selectedRow = value; NotifyPropertyChanged("SelectedRow");}
    }
    SelectedRow = items.First(x => x.whatever == something);
