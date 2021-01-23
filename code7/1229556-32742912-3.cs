    public class ViewModel
    {
        public ViewModel()
        {
            VarConfigList = new ObservableCollection<VarConfig>();
        }
        public ObservableCollection<VarConfig> VarConfigList { get; private set; }
    }
