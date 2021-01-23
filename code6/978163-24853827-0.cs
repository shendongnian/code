    using System.ComponentModel;
    public class ListViewItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            var propChanged = PropertyChanged;
            if(propChanged != null)
            {
                propChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string recentlyChanged = "yes"; // Recently changed on creation
        public string RecentlyChanged
        {
            get { return recentlyChanged; }
            set {
                recentlyChanged = value;
                OnPropertyChanged("RecentlyChanged");
            }
        }
        // ... define the rest of the class as usual
    }
