     public abstract class SourceControlItemViewBaseModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private string _localPath;
        public string LocalPath
        {
            get { return _localPath; }
            set
            {
                _localPath = value;
                OnPropertyChanged();
            }
        }
        private string _serverPath;
        public string ServerPath
        {
            get { return _serverPath; }
            set
            {
                _serverPath = value;
                OnPropertyChanged();
            }
        }
        private string _pendingSetName;
        /// <summary>
        /// Computer name where changes were made
        /// </summary>
        public string PendingSetName
        {
            get { return _pendingSetName; }
            set
            {
                _pendingSetName = value;
                OnPropertyChanged();
            }
        }
        private string _pendingSetOwner;
        /// <summary>
        /// User Name who made the changes
        /// </summary>
        public string PendingSetOwner
        {
            get { return _pendingSetOwner; }
            set
            {
                _pendingSetOwner = value;
                OnPropertyChanged();
            }
        }
        private string _toolTipText;
        public string ToolTipText
        {
            get { return _toolTipText; }
            set
            {
                _toolTipText = value;
                OnPropertyChanged();
            }
        }
        public string SourceServerItem
        {
            get { return _sourceServerItem; }
            set
            {
                _sourceServerItem = value;
                OnPropertyChanged();
            }
        }
        private SourceControlState _state;
        private string _sourceServerItem;
        public SourceControlState State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged();
            }
        }
    }
    
    public class SourceControlFileViewModel : SourceControlItemViewBaseModel
    {
    }
     public class SourceControlDirecoryViewModel : SourceControlItemViewBaseModel
    {
        public List<SourceControlItemViewBaseModel> Items { get; set; }
        public SourceControlDirecoryViewModel()
        {
            Items = new List<SourceControlItemViewBaseModel>();
        }
    }
    [Flags]//My own Enum that represents different states
    public enum SourceControlState
    {
        Online = 0,
        CheckedOut = 1,
        Added = 2,
        Deleted = 4,
        Locked = 8,
        Renamed = 16
    }
