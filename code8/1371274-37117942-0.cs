    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                MyViewModel mvm = new MyViewModel()
                {
                    Flows = new ObservableCollection<Flow>() 
                    { 
                        new Flow() { Name = "Flow1" }, 
                        new Flow() { Name = "Flow2" }, 
                        new Flow() { Name = "Flow3" , Amount=1}, 
                        new Flow() { Name = "Flow4" } 
                    }
                };
                this.DataContext = mvm;
            }
        }
    
        public class MyViewModel : ObservableObject
        {
            private Flow _selectedflow;
            public ObservableCollection<Flow> Flows
            {
                get;
                set;
            }
    
            public Flow SelectedFlow
            {
                get { return _selectedflow; }
                set
                {
                    if (value != _selectedflow)
                    {
                        _selectedflow = value;
                        RaisePropertyChanged("SelectedFlow");
                    }
                }
            }
        }
    
        public class Flow : ObservableObject
        {
            private string _name;
            private int _amount;
            public string Name
            {
                get { return _name; }
                set
                {
                    if (value != _name)
                    {
                        _name = value;
                        RaisePropertyChanged("Name");
                    }
                }
            }
    
            public bool CanDeliver
            {
                get
                {
                    return Amount > 0;
                }
            }
    
            public int Amount
            {
                get { return _amount; }
                set
                {
                    if (value != _amount)
                    {
                        _amount = value;
                        RaisePropertyChanged("Amount");
                        RaisePropertyChanged("CanDeliver");
                    }
                }
            }
        }
    
        public class ObservableObject : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
    
            protected void RaisePropertyChanged(String propertyName)
            {
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            }
        }
    }
