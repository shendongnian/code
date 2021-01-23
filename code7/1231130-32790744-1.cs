    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Windows.Networking;
    using Windows.Networking.Connectivity;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
    namespace TestSO32781692NetworkProtocolConnectivity
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public static readonly DependencyProperty IpV4Property = DependencyProperty.Register(
                "IpV4", typeof(bool), typeof(MainPage), new PropertyMetadata(false));
            public static readonly DependencyProperty IpV6Property = DependencyProperty.Register(
                "IpV6", typeof(bool), typeof(MainPage), new PropertyMetadata(false));
            public static readonly DependencyProperty ProfilesProperty = DependencyProperty.Register(
                "Profiles", typeof(ObservableCollection<string>), typeof(MainPage), new PropertyMetadata(new ObservableCollection<string>()));
            public bool IpV4
            {
                get { return (bool)GetValue(IpV4Property); }
                set { SetValue(IpV4Property, value); }
            }
            public bool IpV6
            {
                get { return (bool)GetValue(IpV6Property); }
                set { SetValue(IpV6Property, value); }
            }
            public ObservableCollection<string> Profiles
            {
                get { return (ObservableCollection<string>)GetValue(ProfilesProperty); }
                set { SetValue(ProfilesProperty, value); }
            }
            public MainPage()
            {
                this.InitializeComponent();
            }
            private async void Button_Click(object sender, RoutedEventArgs e)
            {
                bool ipV4 = false, ipV6 = false;
                ConnectionProfile internetProfile = NetworkInformation.GetInternetConnectionProfile();
                Profiles.Clear();
                Profiles.Add("Internet profile: " + internetProfile.ProfileName);
                var hostNames = NetworkInformation.GetHostNames()
                    .Where(h => h.IPInformation != null &&
                           h.IPInformation.NetworkAdapter != null);
                foreach (HostName hostName in hostNames)
                {
                    ConnectionProfile hostConnectedProfile =
                        await hostName.IPInformation.NetworkAdapter.GetConnectedProfileAsync();
                    if (hostConnectedProfile.NetworkAdapter.NetworkAdapterId == internetProfile.NetworkAdapter.NetworkAdapterId)
                    {
                        Profiles.Add("Host adapter: " + hostName.DisplayName);
                        if (hostName.Type == HostNameType.Ipv4)
                        {
                            ipV4 = true;
                        }
                        else if (hostName.Type == HostNameType.Ipv6)
                        {
                            ipV6 = true;
                        }
                    }
                }
                IpV4 = ipV4;
                IpV6 = ipV6;
            }
        }
    }
