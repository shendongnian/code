        [DllImport("user32.dll")]
        static extern IntPtr LoadImage(
            IntPtr hinst,
            string lpszName,
            uint uType,
            int cxDesired,
            int cyDesired,
            uint fuLoad);
        
        public MainWindow()
        {
            InitializeComponent();
            var image = LoadImage(IntPtr.Zero, "#106", 1, SystemInformation.SmallIconSize.Width, SystemInformation.SmallIconSize.Height, 0);
            var imageSource = Imaging.CreateBitmapSourceFromHIcon(image, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            // Set button content from code
            var sp = new StackPanel
            {
                Orientation = Orientation.Horizontal,
            };
            sp.Children.Add(new Image { Source = imageSource, Stretch = Stretch.None });
           sp.Children.Add(new TextBlock { Text = "OK", Margin = new Thickness(5, 0, 0, 0) });
            OkButton.Content = sp;
        }
