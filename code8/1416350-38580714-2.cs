    using GalaSoft.MvvmLight;
    using System.ComponentModel;
    using System.Net;
    namespace NicApp
    {
        public class AdapterViewModel : ViewModelBase, IDataErrorInfo
        {
            private string _name;
            private string _ipAddress;
            private string _subnet;
            private bool _useDhcp;
            private bool _useDns;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    RaisePropertyChanged();
                }
            }
            public string IPAddress
            {
                get { return _ipAddress; }
                set
                {
                    _ipAddress = value;
                    RaisePropertyChanged();
                }
            }
            public string Subnet
            {
                get { return _subnet; }
                set
                {
                    _subnet = value;
                    RaisePropertyChanged();
                }
            }
            public bool UseDhcp
            {
                get { return _useDhcp; }
                set
                {
                    _useDhcp = value;
                    RaisePropertyChanged();
                }
            }
            public bool UseDns
            {
                get { return _useDns; }
                set
                {
                    _useDns = value;
                    RaisePropertyChanged();
                }
            }
            public string Error
            {
                get
                {
                    return this[nameof(IPAddress)] ?? this[nameof(Subnet)];
                }
            }
            public string this[string columnName]
            {
                get
                {
                    IPAddress addr;
                    if (columnName == nameof(IPAddress) && !UseDhcp && !System.Net.IPAddress.TryParse(IPAddress, out addr))
                        return "Invalid IP Address";
                    if (columnName == nameof(Subnet) && !UseDhcp && !System.Net.IPAddress.TryParse(Subnet, out addr))
                        return "Invalid Subnet Mask";
                    return null;
                }
            }
        }
    }
