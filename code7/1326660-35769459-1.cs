    public class Localize : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChange(String name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        //Declarations
        private static ResourceFile _localizedStrings = new ResourceFile();
        public ResourceFile LocalizedStrings
        {
            get { return _localizedStrings; }
            set { NotifyChange("LocalizedStrings"); }
        }
    }
