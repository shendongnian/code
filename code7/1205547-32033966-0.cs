    public class someClass
        {
            private static bool _registerUIMapping = false;
        public CopyNPasteBottemViewModel()
        {
            if (!_registerUIMapping)
            {
                ResourceDictionary MyResourceDictionary = new ResourceDictionary();
                MyResourceDictionary.Source = new Uri("somePath/UIMapping.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Add(MyResourceDictionary);
                _registerUIMapping = true;
            }
        }
        private bool _doThisForTheNextConflictProperty = false;
        public bool DoThisForTheNextConflict
        {
            get 
            {
                return _doThisForTheNextConflictProperty;
            }
            set
            {
                _doThisForTheNextConflictProperty = value;
                    OnPropertyChanged("DoThisForTheNextConflict");
            }
        }
    }
