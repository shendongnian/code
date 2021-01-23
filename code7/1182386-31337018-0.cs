    public EquipmentManagerViewModel()
    {
        SelectItemCommand = new RelayCommand<String>(obj => GetItemHeader(obj.ToString()));
    }
    public RelayCommand<String> SelectItemCommand { get; private set; }
    private void GetItemHeader(string selectedHeader)
    {
        MessageBox.Show(selectedHeader);
    }
