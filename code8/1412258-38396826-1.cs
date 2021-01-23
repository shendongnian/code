          public class MasterViewModel : ViewModelBase
          {
            private ParentViewModel _SelectedParent;
    
            public ParentViewModel SelectedParent
            {
                get { return _SelectedParent; }
                set { _SelectedParent = value; OnPropertyChanged("SelectedParent"); }
            }
    
            private int _SelectedParentIndex;
    
            public int SelectedParentIndex
            {
                get { return _SelectedParentIndex; }
                set { _SelectedParentIndex = value; OnPropertyChanged("SelectedParentIndex"); }
            }
    
            public ObservableCollection<ParentViewModel> ParentViewModels
            {
                get; private set;
            }
    
            public MasterViewModel()
            {
                ParentViewModels = new ObservableCollection<ParentViewModel>();
                LoadData();
            }
    
            private void LoadData()
            {
                for(int x = 0; x < 10; x++)
                {
                    ParentViewModel parent = new ParentViewModel();
                    parent.ChildChangedEvent += Parent_ChildChangedEvent;
                    for(int y = 0; y < 20; y++)
                    {
                        ChildViewModel child = new ChildViewModel() { ChildName = "Child " + y };
                        parent.ChildViewModels.Add(child);
                    }
                    ParentViewModels.Add(parent);
                }
            }
    
            private void Parent_ChildChangedEvent(object sender, EventArgs e)
            {
                SelectedParent = (ParentViewModel)sender;
            }
        }
