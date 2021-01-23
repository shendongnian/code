        public class MainSubViewModel : BaseObservableObject
    {
        private int _selectedComboItem;
        private ICommand _command;
        private bool _isControlVisible;
        public MainSubViewModel()
        {
            IsControlVisible = true;
        }
        public ICommand Command
        {
            get { return _command ?? (_command = new RelayCommand(CommandMethod)); }
        }
        private void CommandMethod()
        {
            if (SelectedComboItem == 8)
                IsControlVisible = false;
        }
        public bool IsControlVisible
        {
            get { return _isControlVisible; }
            set
            {
                _isControlVisible = value;
                OnPropertyChanged();
            }
        }
        public int SelectedComboItem
        {
            get { return _selectedComboItem; }
            set
            {
                _selectedComboItem = value;
                OnPropertyChanged();
            }
        }
    }
