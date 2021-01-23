        DocumentManager mgr;
        Window2 w2;
        public MainWindow()
        {
            InitializeComponent(); 
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        { 
            mgr = new DocumentManager();
            w2 = new Window2();
            w2.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageSource imgsource;
            string imglocation;
            try 
            {
                imglocation = mgr.openfile().ToString();
                imgsource = new BitmapImage(new Uri(imglocation));
                result.Text = imglocation;
                w2.imgsource = imgsource;
            }
            catch (Exception ex)
            { System.Windows.MessageBox.Show(ex.Message); }
        }
    }
