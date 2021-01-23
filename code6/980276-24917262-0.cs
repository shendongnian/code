        DocumentManager mgr;
        public MainWindow()
        {
            InitializeComponent(); 
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        { mgr = new DocumentManager(); }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageSource imgsource;
            string imglocation;
            try 
            {
                imglocation = mgr.openfile().ToString();
                imgsource = new BitmapImage(new Uri(imglocation));
                result.Text = imglocation;
                OpenedImage.Source = imgsource;
            }
            catch (Exception ex)
            { System.Windows.MessageBox.Show(ex.Message); }
        }
    }
