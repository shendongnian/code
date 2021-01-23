    // The constructor of the client class that must be notified the mousemove event
      public WebBrowserAdapter()
      {
          InitializeComponent();
          this.Loaded += WebBrowserAdapter_Loaded;
          mouseMoveManager = new DomMouseMoveEventManager();
          mouseMoveManager.DomMouseMove += mouseMoveManager_DomMouseMove;
      }
    
      void mouseMoveManager_DomMouseMove(object source, DomMouseMoveEventArgs args)
      {
          diagnosticBlock.Text = "[" + args.ClientX + "; " + args.ClientY + "]";
          OnDomMouseMove(args.ClientX, args.ClientY);
      }
