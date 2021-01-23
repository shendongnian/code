    using System;
    using System.Windows;
    using System.ComponentModel;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private string inputText = "Initial Value";
    
            public string InputText
            {
                get { return inputText; }
                set
                {
                    inputText = value;
                    NotifyPropertyChanged("InputText");
                }
            }
    
            public MainWindow()
            {
                this.DataContext = this;
    
                InitializeComponent();
    
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected void NotifyPropertyChanged(String property)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
                }
            }
        }
    }
