    using System.ComponentModel;
    using System.Windows;
    
    namespace Wpf_2FormSync
    {
        /// <summary>
        /// Interaction logic for ChildWindow.xaml
        /// </summary>
        public partial class ChildWindow : Window, INotifyPropertyChanged
        {
            private string _myName = "";
            public string MyName
            {
                get { return _myName; }
                set
                {
                    if (value == _myName) return;
                    _myName = value;
                    NotifyOfPropertyChanged("MyName");
                }
            }
    
            public ChildWindow()
            {
                InitializeComponent();
                
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyOfPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                MessageBox.Show(MyName);
            }
    
    
        }
    }
