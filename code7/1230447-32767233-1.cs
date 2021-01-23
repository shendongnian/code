    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class HealthDisease
    {
        public string Name { get; set; }
    }
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<HealthDisease> EntityList { get; set; }
        public MainViewModel()
        {
            RetrieveMany();
        }
        private void RetrieveMany()
        {
            EntityList = new ObservableCollection<HealthDisease>
            {
                new HealthDisease {Name = "Disease A"},
                new HealthDisease {Name = "Disease B"},
                new HealthDisease {Name = "Disease C"}
            };
        }
        private HealthDisease highlighted;
        public HealthDisease Highlighted
        {
            get { return highlighted; }
            set
            {
                highlighted = value;
                OnPropertyChanged();
                OnPropertyChanged("HighlightedName");
            }
        }
        public string HighlightedName
        {
            get { return Highlighted == null ? string.Empty : Highlighted.Name; }
        }
    }
