        using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    
    namespace WpfApplication
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            private string disconnectedDevices;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
    
            public MainViewModel()
            {
                ToggleExecuteCommand = new RelayCommand(ChangeCollection);
                DeviceCollection = new ObservableCollection<DeviceInformationVM>();
                DeviceCollection.CollectionChanged += DeviceCollection_CollectionChanged;
            }
    
            private void ChangeCollection(object obj)
            {
                DeviceCollection.Add(new DeviceInformationVM { MyProperty = "TEST" });
            }
    
            private void DeviceCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                NotifyCollectionChangedAction action = e.Action;
    
                if (action == NotifyCollectionChangedAction.Add)
                {
                    DisconnectedDevices = "Somme thing added to collection";
                }
    
                if (action == NotifyCollectionChangedAction.Remove)
                {
                    DisconnectedDevices = "Somme thing removed from collection";
                }
            }
    
            public string DisconnectedDevices
            {
                get { return this.disconnectedDevices; }
    
                set
                {
                    if (value != this.disconnectedDevices)
                    {
                        this.disconnectedDevices = value;
                        NotifyPropertyChanged("DisconnectedDevices");
                    }
                }
            }
    
            public ObservableCollection<DeviceInformationVM> DeviceCollection { get; set; }
    
            public RelayCommand ToggleExecuteCommand { get; set; }
    
        }
    }
    
