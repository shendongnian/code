        public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                ApplyTheme();
    
                InitializeComponent();
            }
    
            private static void ApplyTheme()
            {
                if ((App.Current as App).WhiteTheme)
                {
                    var whiteTheme = new WhiteTheme();
    
                    foreach (var key in whiteTheme.Keys)
                    {
                        if (Application.Current.Resources.ContainsKey(key))
                            Application.Current.Resources[key] = whiteTheme[key];
                    }
                }
            }
        }
