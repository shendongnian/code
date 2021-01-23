    public class GroupListViewModel : INotifyPropertyChanged
    {
        public GroupListViewModel()
        {
            // Get your actual data
            var groupsData = new List<GroupViewModel>
            {
                new GroupViewModel(new GroupTable {Id = 1, Name = "Group 1"}),
                new GroupViewModel(new GroupTable {Id = 2, Name = "Group 2"})
            };
            this.Groups = new ObservableCollection<GroupViewModel>(groupsData);
        }
        private ObservableCollection<GroupViewModel> _Groups;
        public ObservableCollection<GroupViewModel> Groups
        {
            get { return _Groups; }
            set
            {
                _Groups = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
