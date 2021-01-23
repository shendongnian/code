    public class DataGridViewModel : ViewModelBase
        {
         private ObservableCollection<MyViewModel> _source;
            public ObservableCollection<MyViewModel> Source
            {
                get { return _source; }
                set
                {
                    _source= value;
                    OnPropertyChanged();
                }
            }
    }
