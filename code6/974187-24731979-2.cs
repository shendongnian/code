    public partial class MainWindow : Window
    {
        public ObservableCollection<MachineFunction> MachineFunctions { get; set; }
    
        public MainWindow()
        {
            InitializeComponent();
    
            lstMachineFunctions.ItemsSource = MachineFunctions = new ObservableCollection<MachineFunction>();
        }
    
        private void OnDeleteMachineFunction(object sender, RoutedEventArgs e)
        {
            MachineFunctions.Remove((sender as FrameworkElement).DataContext as MachineFunction);
        }
    
        private void OnAddMachineFunction(object sender, RoutedEventArgs e)
        {
            MachineFunctions.Add(new MachineFunction());   
        }
    
        private void OnAddScaleUnit(object sender, RoutedEventArgs e)
        {
            var mf = (sender as FrameworkElement).DataContext as MachineFunction;
    
            mf.ScaleUnits.Add(new ScaleUnit(mf.ScaleUnits.Count));
        }
    
        private void OnDeleteScaleUnit(object sender, RoutedEventArgs e)
        {
            var delScaleUnit = (sender as FrameworkElement).DataContext as ScaleUnit;
    
            var mf = MachineFunctions.FirstOrDefault(_ => _.ScaleUnits.Contains(delScaleUnit));
    
            if( mf != null )
            {
                mf.ScaleUnits.Remove(delScaleUnit);
    
                foreach (var scaleUnit in mf.ScaleUnits)
    	        {
    		        scaleUnit.Index = mf.ScaleUnits.IndexOf(scaleUnit);
    	        }
            }
        }
    }
