    public Form1()
    { 
    	try 
    	{
            InitializeComponent();
            string n = wc.DownloadString("https://www.dropbox.com/s/znog54omhbhxwej/n.txt?dl=1");
            NEWS.Text = n;
    	}
    	catch (WebException wEx) 
    	{
    		 MessageBox.Show("No internet connection");  
    	}
    	catch (Exception ex)
    	{
    		System.Diagnostics.WriteLine(ex.Message);
    	}
    }
