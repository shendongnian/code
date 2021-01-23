        public sealed partial class SettingPage : Page
        {
            public SettingPage()
            {
                this.InitializeComponent();
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                ApplicationDataContainer localsettings = ApplicationData.Current.LocalSettings;
                localsettings.Values["SplitViewColoronShell"] = Colors.Yellow.ToString();
            }
        }
