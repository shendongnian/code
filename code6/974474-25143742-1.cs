    namespace VLC_Test
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
      public partial class MainWindow : Window
      {
        AxAXVLC.AxVLCPlugin vlcPlayer = new AxAXVLC.AxVLCPlugin();
        Window2 win2;
    
        public MainWindow()
        {
            InitializeComponent();
            WFH1.Child = vlcPlayer;           
    
        }
    
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            win2 = new Window2();
            win2.Show();
    
            string file1 = @"C:\Users\Username\Desktop\drop.avi";
    
            vlcPlayer.addTarget("file:///" + file1, null,     AXVLC.VLCPlaylistMode.VLCPlayListReplaceAndGo, 0);
            vlcPlayer.play();
        }    
		private void Window_Resize(object sender, SizeChangedEventArgs e)
		{
			if (win2 != null)
			{
				win2.Height = e.NewSize.Height;
				win2.Width = e.NewSize.Width;
			}
		}
      }
    }
