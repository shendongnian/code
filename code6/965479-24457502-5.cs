    /// <summary>
    /// Interaction logic for HyperVControl.xaml
    /// </summary>
    public partial class HyperVControl : UserControl, INotifyPropertyChanged
    {
        #region Constructors
        
        public HyperVControl()
        {
            // Form initialization
            InitializeComponent();
            
            // Initialize columns visibility collection
            IDictionary<String, Boolean> innerColumnsVisibilityDictionary = new Dictionary<String, Boolean>();
            innerColumnsVisibilityDictionary.Add("ElementName", true);
            // Wrap the visibility dictionary
            this.ColumnsVisibility = new DictionaryNotificationWrapper<String, Boolean>(innerColumnsVisibilityDictionary);
            // Initialize grid's datasource
            this.HVMachineList = new ObservableCollection<HyperVMachine>();
            this.HVMachineList.Add(new HyperVMachine());
            this.HVMachineList.Add(new HyperVMachine());
            this.HVMachineList.Add(new HyperVMachine());
        }
