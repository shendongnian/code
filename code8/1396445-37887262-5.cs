    using System;
    using System.ComponentModel;
    using System.Windows;
    
    
    namespace Wpf_2FormSync
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private ChildWindow _childWindow = null;
            private string _myName = "";
            public string MyName
            {
                get { return _myName; }
                set
                {
                    if (value == _myName) return;
                    _myName = value;
                    NotifyOfPropertyChanged("MyName");
                    if (_childWindow != null)
                        _childWindow.MyName = value;
                }
            }
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                _childWindow = new ChildWindow();
                _childWindow.Show();
                _childWindow.MyName = "John";
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyOfPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    
            }
    
            private void Button_Click_2(object sender, RoutedEventArgs e)
            {
                if (_childWindow != null)
                    _childWindow.MyName = this.MyName;
            }
        }
    }
