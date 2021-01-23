    using System.Windows;
    using System.Collections.ObjectModel;
    
    namespace WpfApplication2
    {
        public class Thing
        {
            // make sure this is a property, not a field.
            // furthermore, make sure it is public. 
            public ObservableCollection<string> stuff
            {
                get; set;
            }
    
            public Thing()
            {
                stuff = new ObservableCollection<string>();
                stuff.Add("A String");
                stuff.Add("Another String");
                stuff.Add("Yet Another String");
            }
        }
    
        public partial class MainWindow : Window
        {
            public Thing thing{get;set;}
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                thing = new Thing();
            }
        }
    }
