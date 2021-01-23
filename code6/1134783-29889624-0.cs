    void Main()
    {
        SplashScreen.ShowText("Loading 1");
        Thread.Sleep(1000);
        SplashScreen.ShowText("Loading 2");
        Thread.Sleep(2000);
        SplashScreen.Done();
        Thread.Sleep(2000);
        SplashScreen.ShowText("Loading 3");
    }
    
    // Define other methods and classes here
    public partial class SplashScreen : Form
    {
      private static SplashScreen instance;
      private static readonly ManualResetEvent initEvent = new ManualResetEvent(false);
      
      Label loadLabel;
    
      private SplashScreen()
      {
        // InitializeComponent();
        loadLabel = new Label();
        Controls.Add(loadLabel);
        
        Load += (s, e) => initEvent.Set();
        Closing += (s, e) => initEvent.Reset();
      }
      
      private static object syncObject = new object();
      private static void InitializeIfRequired()
      {
        // If not set, we'll have to init the message loop
        if (!initEvent.WaitOne(0))
        {
          lock (syncObject)
          {
            // Someone initialized it before us
            if (initEvent.WaitOne(0)) return;
            
            // Recreate the form if it was closed
            instance = new SplashScreen();
            
            var thread = new Thread(() => { Application.Run(instance); });
            thread.Start();
            
            // Wait until the form is ready
            initEvent.WaitOne();
          }
        }
      }
      
      public static void ShowText(string text)
      {
        InitializeIfRequired();
        
        instance.Invoke((Action)(() => { instance.loadLabel.Text = text; }));
      }
      
      public static void Done()
      {
        // Is it closed already?
        if (!initEvent.WaitOne(0)) return;
    
        lock (syncObject)
        {
          // Someone closed it before us
          if (!initEvent.WaitOne(0)) return;
    
          instance.Invoke((Action)(() => { instance.Close(); }));
        }
      }
    }
