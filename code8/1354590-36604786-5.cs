    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    
    
    namespace Sandpit
    {
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public ObservableCollection<Routing> routes;
            public ObservableCollection<Routing> Routes 
            {
                get
                {
                    return routes;
                }
    
                set
                {
                    if (value != routes)
                    {
                        routes = value;
                        NotifyPropertyChanged("Routes");
                    }
                }
            }
            public MainWindow()
            {
                Routes = new ObservableCollection<Routing>();
                Routes.Add(new Routing { Product = "A", Quality = "C" });
                Routes.Add(new Routing { Product = "B", Quality = "D" });
                InitializeComponent();
                DataContext = this;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged(String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
