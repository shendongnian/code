        public class ParentViewModel : ViewModelBase
        {
            public String ParentName { get; set; }
            private int _SelectedChildIndex;
    
            public int SelectedChildIndex
            {
                get { return _SelectedChildIndex; }
                set { _SelectedChildIndex = value; OnPropertyChanged("SelectedChildIndex"); }
            }
    
            private ChildViewModel _SelectedChild;
    
            public ChildViewModel SelectedChild
            {
                get { return _SelectedChild; }
                set
                {
                    _SelectedChild = value;
                    OnPropertyChanged("SelectedChild");
                    if (ChildChangedEvent != null)
                    {
                        ChildChangedEvent(this, new EventArgs());
                    }
                }
            }
    
            public ObservableCollection<ChildViewModel> ChildViewModels
            {
                get; private set;
            }
    
            public event EventHandler ChildChangedEvent;
    
            public ParentViewModel()
            {
                ChildViewModels = new ObservableCollection<ChildViewModel>();
            }
        }
