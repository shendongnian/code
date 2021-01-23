    class DataViewCollectionModel : BindableObject
    {
        private ObservableCollection<DataViewModel> dataVMs;
        private DataViewModel selectedItemInVM;
        public ObservableCollection<DataViewModel> DataVMs
        {
            get { return dataVMs; }
            set
            {
                if (dataVMs != value)
                {
                    dataVMs = value;
                    NotifyPropertyChanged("DataVMs");
                }
            }
        }
    
        public DataViewModel SelectedItemInVM
        {
            get { return selectedItemInVM; }
            set
            {
                if (selectedItemInVM != value)
                {
                    selectedItemInVM = value;
                    NotifyPropertyChanged("SelectedItemInVM");
                }
            }
        }
    
        private RelayCommand<DataViewModel> deleteCommand;
        public RelayCommand<DataViewModel> DeleteCommand
        {
            get { return deleteCommand ?? (deleteCommand = new RelayCommand<DataViewModel>(d => Delete(d))); }
        }
    
        private void Delete(DataViewModel d)
        {
            DataVMs.Remove(selectedItemInVM);
        }
        
    }
