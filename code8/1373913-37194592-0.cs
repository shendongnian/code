    public string SelectedParam { get { return _selectedParam; } 
    set { _selectedParam = value; NotifyPropertyChanged("SelectedParam");
    if (_selectedParam == "ingen") { BindData(); } 
    else { hjuldata.ItemsSource = FilterKategori().Tables[0].DefaultView; ; } } } 
    private void BindData() { hjuldata.ItemsSource = kategori().Tables[0].DefaultView; };` 
