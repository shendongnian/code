    public class MyComboDataContext:BaseObservableObject
    {
        private int _categoryId;
        private ICommand _selectionChangedCommand;
        public MyComboDataContext()
        {
            CategoryId = 1;
        }
        public int CategoryId
        {
            get { return _categoryId; }
            set
            {
                _categoryId = value;
                OnPropertyChanged();
            }
        }
        public ICommand SelectionChangedCommand
        {
            get { return _selectionChangedCommand ?? (_selectionChangedCommand = new RelayCommand(SelectionChanger)); }
        }
        private void SelectionChanger()
        {
            CategoryId += 1;
            if (CategoryId == 4)
                CategoryId = 1;
        }
    }
