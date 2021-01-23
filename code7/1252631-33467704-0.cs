    System.Windows.Forms.Timer timer = new Timer();
    void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        // other processes
    	timer.Interval = 1 * 1000 * 5; // 5 seconds
    	timer.Tick += timer_Tick;
    	timer.Start();
    }
    
    void timer_Tick(object sender, EventArgs e)
    {
    	timer.Tick -= timer_Tick;
    
    	HtmlElement logo = webBrowser1.Document.CreateElement("img");
    	logo.SetAttribute("SRC", @"file:///C:/Users/Susana/Documents/Projeto HaxballK/Design/Logo HK.png");
    	webBrowser1.Document.Body.AppendChild(logo);
    	logo.SetAttribute("float", "right");
    }
