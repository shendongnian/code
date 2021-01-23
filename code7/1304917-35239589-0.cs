    public WMain() {
      System.Windows.Forms.Application.EnableVisualStyles();
      InitializeComponent();
          
      WbThumbs.DocumentCompleted += WbThumbsOnDocumentCompleted;
      WbThumbs.Navigate("www.blabla.com");
    }
    private void WbThumbsOnDocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e) {
      if (WbThumbs.Document == null) return;
      WbThumbs.Document.Click += WbThumbs_Click;
    }
    private void WbThumbs_Click(object sender, System.Windows.Forms.HtmlElementEventArgs e) {
      var doc = WbThumbs.Document;
      var src = doc?.GetElementFromPoint(e.ClientMousePosition);
      if (src == null) return;
      //...
    }
