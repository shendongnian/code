    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
    
            App currentApp = (App)Application.Current;
    
            string uriString = currentApp.PageData["mediaurl"];
    
            MessageBox.Show(uriString);
            //reference item by name
            Microsoft.SilverlightMediaFramework.Core.Media.PlaylistItem item = this.playListItem;
            item.MediaSource = new Uri(uriString, UriKind.Absolute);
            //...other code
        }
    }
