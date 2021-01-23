    <DataGrid SelectedValuePath="Size Quantity" SelectedValue="{Binding SelectionValue}" 
    private string _selectedValue
    public string SelectionValue 
      {
    get { return _selectedValue; }
    set { _selectedValue = value; NotifyPropertyChanged("SelectionValue"); }
    }
    SelectionValue = "Blue";
