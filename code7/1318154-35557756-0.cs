         public ControlMachineII()
                {
                    InitializeComponent();
                    DataContextChanged += new DependencyPropertyChangedEventHandler(ControlMachineII_DataContextChanged);
                 
                  
                }
    
       private void ControlMachineII_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                string compname = (this.DataContext as Model.Model.ControleData).ComputerName;
                Console.WriteLine("DataContext initialized computername :" +compname);
            }
