    public ObservableCollection<ImageSource> SelectedImageList
    {
       get { return _selectedImageList; }
       set { _selectedImageList = value; 
           SendPropertyChanged("SelectedImageList"); // suppose you have implemented INotifyPropertyChanged interface in this method.
           }
    }
