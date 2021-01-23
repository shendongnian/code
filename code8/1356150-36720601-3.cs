    using Microsoft.SilverlightMediaFramework.Core.Media;
    using Microsoft.SilverlightMediaFramework.Plugins.Primitives;
    /...
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
    
            App currentApp = (App)Application.Current;
    
            string uriString = currentApp.PageData["mediaurl"];
    
            var item = new PlaylistItem();
            item.MediaSource = new Uri(uriString, UriKind.Absolute);
            item.DeliveryMethod = DeliveryMethods.AdaptiveStreaming;
     
            //Add PlaylistItem to the Media playlist
            sMFPlayer.Playlist.Add(item);
            sMFPlayer.Play();
        }
    }
