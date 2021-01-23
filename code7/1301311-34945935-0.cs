    Public Form1()
    {
    	InitializeComponent();
     
    	SystemEvents.SessionEnding += SessionEndingEvtHandler;          
    }
    
    private void SessionEndingEvtHandler(object sender, SessionEndingEventArgs e)
    {
    	e.Cancel = true;
    }
