     public Cover():base()
            {
                InitializeComponent();
    
                //Loaded += (s, e) =>
                //{
                //    Animation01.Begin(); // THIS IS WRONG
                //};
    
                IsValid = true;
                this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            }
   
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                Storyboard sb = this.FindResource("Animation01") as Storyboard;                   
                sb.Begin();
            }
