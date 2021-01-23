    using System.Collections.Generic;
    
    namespace WpfApplication1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = new List<MyModel>
                {
                    new MyModel {Number = 1, Value = "one"},
                    new MyModel {Number = 2, Value = "two"}
                };
            }
        }
    }
