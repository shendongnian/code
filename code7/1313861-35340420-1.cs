    private ObservableCollection<YourItemType> selectedItems = new ObservableCollection<YourItemType>();
        public ObservableCollection<YourItemType> SelectedItems
        {
            get { return selectedItems; }
            set
            {
                if (selectedItems != value)
                {
                    selectedItems = value;
                    RaisePropertyChanged(() => SelectedItems);
                }
            }
        }
