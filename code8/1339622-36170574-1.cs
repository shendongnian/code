    public sealed partial class MyUserControl : UserControl
    {
        public ObservableCollection<RoomInfo> roominfo;
    
        public MyUserControl()
        {
            this.InitializeComponent();
            roominfo = new ObservableCollection<RoomInfo>();
            roominfo.Clear();
            roominfo.Add(new RoomInfo { RoomNo = "2NR12", host = "Available", Status = "Available", ellipseColor = "#FF008000", Date = "June 18,2016", TimeFrom = "02:00", TimeTo = "03:00" });
            roominfo.Add(new RoomInfo { RoomNo = "2NR12", host = "Ayman", Status = "Meeting", ellipseColor = "#FFFF0000", Date = "June 19,2016", TimeFrom = "11:00", TimeTo = "All Day" });
        }
    
        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            dropDown.Visibility = Visibility.Visible;
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dropDown.Visibility = Visibility.Collapsed;
        }
    }
