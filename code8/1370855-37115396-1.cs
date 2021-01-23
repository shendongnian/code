    private string _selectedParam;
    public string SelectedParam 
    {
      get{return _selectedParam;}
      set
      {
         _selectedParam = value;  
         NotifyPropertyChanged("SelectedParam");
         hjuldata.ItemsSource = FilterKategori(_selectedParam).Tables[0].DefaultView;
 
      }
    }
