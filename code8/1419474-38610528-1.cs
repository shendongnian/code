    using System.Windows;
    using System.Collections.Generic;
    using System.Windows.Controls.DataVisualization.Charting;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    
        public class MainWindowViewModel
        {
            private List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>()
            {
                (new KeyValuePair<string, int>("Developer", 60)),
                (new KeyValuePair<string, int>("Misc", 20)),
                (new KeyValuePair<string, int>("Tester", 50)),
                (new KeyValuePair<string, int>("QA", 30)),
                (new KeyValuePair<string, int>("Project Manager", 40))
            };
    
            public List<KeyValuePair<string, int>> ValueList
            {
                get { return valueList; }
            }
        }
    }
