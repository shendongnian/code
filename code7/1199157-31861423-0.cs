    namespace TryAccelerometer
    {        
        public sealed partial class MainPage : Page
        {
            private Accelerometer acc;
            private DispatcherTimer timer;                
            private int numberAcc = 0;
            private int numberTimer = 0;
            private CoreDispatcher dispatcher;
    
            public MainPage()
            {
                this.InitializeComponent();
                this.NavigationCacheMode = NavigationCacheMode.Required;
    
                dispatcher = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
    
                acc = Accelerometer.GetDefault();                                    
                acc.ReadingChanged += acc_ReadingChanged;
    
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(2);
                timer.Tick += timer_Tick;
                timer.Start();            
            }
    
            async void acc_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
            {            
                await dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    numberAcc++;
                });
            }
    
            void timer_Tick(object sender, object e)
            {
                numberTimer++;            
                acc.ReportInterval = acc.ReportInterval++;
                //acc.ReadingChanged -= acc_ReadingChanged;
            }
            /// <summary>
            /// Invoked when this page is about to be displayed in a Frame.
            /// </summary>
            /// <param name="e">Event data that describes how this page was reached.
            /// This parameter is typically used to configure the page.</param>
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                // TODO: Prepare page for display here.
    
                // TODO: If your application contains multiple pages, ensure that you are
                // handling the hardware Back button by registering for the
                // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
                // If you are using the NavigationHelper provided by some templates,
                // this event is handled for you.
            }
        }
    }
