    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;
    using System.Collections.ObjectModel;
    using System.Linq;
    namespace NicApp
    {
        public class MainViewModel : ViewModelBase
        {
            public MainViewModel()
            {
                // TODO actually load adapters
                Adapters = new ObservableCollection<AdapterViewModel>();
                Adapters.Add(new AdapterViewModel
                {
                    Name = "Ethermet",
                    IPAddress = "192.168.1.100",
                    Subnet = "255.255.255.0",
                    UseDhcp = true,
                    UseDns = true
                });
                Adapters.Add(new AdapterViewModel
                {
                    Name = "Wireless",
                    IPAddress = "192.168.1.101",
                    Subnet = "255.255.255.0",
                    UseDhcp = false,
                    UseDns = false
                });
            }
            private ObservableCollection<AdapterViewModel> _adapters;
            public ObservableCollection<AdapterViewModel> Adapters
            {
                get { return _adapters; }
                set { _adapters = value; RaisePropertyChanged(); }
            }
            private RelayCommand _acceptCommand;
            private RelayCommand _cancelCommand;
            public RelayCommand AcceptCommand
            {
                get
                {
                    return _acceptCommand ?? (_acceptCommand = new RelayCommand(() =>
                    {
                        // Accept action
                    }, () => Adapters.All(_ => _.Error == null)));
                }
            }
            public RelayCommand CancelCommand
            {
                get
                {
                    return _cancelCommand ?? (_cancelCommand = new RelayCommand(() =>
                    {
                        // Cancel action
                    }));
                }
            }
        }
    }
