    namespace ABC
    {
    public partial class MainContentArea : Form
    {
        private string _currentId;        
        public MainContentArea(string topicId, Menu menu)
        {
            InitializeComponent();
            _currentId = topicId;
            _menu = menu;
            WMPLib.IWMPPlaylist p2 = axWindowsMediaPlayer.playlistCollection.newPlaylist("Playlist 1");
            CreatePlaylist(_currentId, p2);
        }
    private void CreatePlaylist(string _currentId, WMPLib.IWMPPlaylist p2)
    {    
       var selectedElementJumpToValue = MainContentAreaBl.GetSelectedElementValue(_currentId, "jumpTo");
       string selectedElementPageTypeValue = MainContentAreaBl.GetSelectedElementPageTypeValue(selectedElementJumpToValue);            
       if (selectedElementJumpToValue != null)
       {
          _currentId = selectedElementJumpToValue;                
          if (_currentId != null && _currentId != "menu" && selectedElementPageTypeValue == "video")
          {
             var playerFile = Path.Combine(Common.ContentFolderPath, MainContentAreaBl.GetSelectedElementDataPathValue(_currentId));                    
             p2.appendItem(axWindowsMediaPlayer.newMedia(playerFile));
             axWindowsMediaPlayer.currentPlaylist = p2;
                    CreatePlaylist(_currentId, p2);
          }
                //axWindowsMediaPlayer.BringToFront();
       }
            axWindowsMediaPlayer.Ctlcontrols.play();
    }
    }
    }
