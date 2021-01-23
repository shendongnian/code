    public class Vm
    {
        public ObservableCollection<PluginViewModel> PluginVMs
        {
            get { return _pluginVMs; }
            set
            {
                if (_pluginVMs != value)
                {
                    _pluginVMs = value;
                    NotifyPropertyChanged("PluginVMs");
                }
            }
        }
    
        public ICommand DupeCmd { get; private set; }
    }
