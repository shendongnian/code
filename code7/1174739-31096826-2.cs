      public MainWindow()
        {
            InitializeComponent();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            string subpath = "UserProfile";
            Directory.CreateDirectory(subpath);
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "jpeg Files (*.jpg)|*.jpg";
            // Display OpenFileDialog by calling ShowDialog method 
            if (dlg.ShowDialog() == true)
            {
                string fileName = "pic" + txtEmployeeID.Text + ".jpg";
                string newPath = "\\" + subpath + "\\" + fileName;
                if (File.Exists(Directory.GetCurrentDirectory() + "\\" + newPath))
                {
                    imgUser.Source = null;
                    File.Delete(Directory.GetCurrentDirectory() + newPath);
                }
                File.Copy(dlg.FileName.ToString(), Directory.GetCurrentDirectory() + "\\" + newPath);
                ImageSource imageSrc = BitmapFromUri(new Uri(Directory.GetCurrentDirectory() + newPath));
                imgUser.Source = imageSrc;
            }
        }
        public static ImageSource BitmapFromUri(Uri source)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(source.AbsoluteUri);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            return bitmap;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            string subpath = "UserProfile";
            Directory.CreateDirectory(subpath);
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "jpeg Files (*.jpg)|*.jpg";
            // Display OpenFileDialog by calling ShowDialog method 
            if (dlg.ShowDialog() == true)
            {
                string fileName = "pic" + DateTime.Now.Millisecond + ".jpg";
                string newPath = "\\" + subpath + "\\" + fileName;
                if (File.Exists(Directory.GetCurrentDirectory() + "\\" + newPath))
                {
                    imgUser.Source = null;
                    // File.Delete(Directory.GetCurrentDirectory() + newPath);
                }
                File.Copy(dlg.FileName.ToString(), Directory.GetCurrentDirectory() + "\\" + newPath);
                ImageSource imageSrc = BitmapFromUri(new Uri(Directory.GetCurrentDirectory() + newPath));
                imgUser.Source = imageSrc;
            }
        }
