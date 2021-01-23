    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        
            private void SwitchOpacity_OnClick(object sender, RoutedEventArgs e)
            {
    
                int opacityVal = 0;
    
                Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i <= 1000; i++)
                    {
                        int j = 0;
                        Thread.Sleep(100);
    
    
                        //Use ++ % to change Opacity
                        this.Dispatcher.Invoke(
                            DispatcherPriority.SystemIdle,
                            new Action(() =>
                            {
                                WhiteMaskCanvas.Opacity = ++opacityVal % 10 / 10.0;
                            }));
    
    
                        ////Use Abs Cosine to Change Opacity 
                        //this.Dispatcher.Invoke(
                        //    DispatcherPriority.SystemIdle,
                        //    new Action(() =>
                        //    {
                        //        WhiteMaskCanvas.Opacity = 
                        //            Math.Abs(Math.Sin(++opacityVal*0.1)) ;
                        //    }));
    
                    }
                });
    
            }
    
        }
