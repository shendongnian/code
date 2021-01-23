    public class GroupViewModel : INotifyPropertyChanged
    {
        public GroupViewModel(GroupTable group)
        {
            this.GroupName = group.Name;
            this.GroupIsChecked = GroupCheckedLogic();
        }
        private string _GroupName;
        public string GroupName
        {
            get { return _GroupName; }
            set
            {
                _GroupName = value;
                OnPropertyChanged();
            }
        }
        private bool _GroupIsChecked;
        public bool GroupIsChecked
        {
            get { return _GroupIsChecked; }
            set
            {
                _GroupIsChecked = value;
                OnPropertyChanged();
            }
        }
        private bool GroupCheckedLogic()
        {
            // Your logic goes here
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
