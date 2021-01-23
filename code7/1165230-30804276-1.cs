    public MainWindow()
            {
                InitializeComponent();
    
                Uri myUri = new Uri(@"Images\2b3601fe2b62e87481bd301da52a2182.gif", UriKind.RelativeOrAbsolute);
                GifBitmapDecoder decoder2 = new GifBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bitmapSource2;
                int frameCount = decoder2.Frames.Count;
    
                Thread th = new Thread(() => {
                    while (true)
                    {
                        for (int i = 0; i < frameCount; i++)
                        {
                            this.Dispatcher.Invoke(new Action(delegate()
                            {
                                bitmapSource2 = decoder2.Frames[i];
                                image.Source = bitmapSource2;
                            }));
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                });
                th.Start();
            }
