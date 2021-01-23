    public Form1()
    { 
        InitializeComponent();
        try
          { string n = wc.DownloadString("https://www.dropbox.com/s/znog54omhbhxwej/n.txt?dl=1");
        NEWS.Text = n;
          }
        catch(Exception objException)
          { System.Diagnostics.WriteLine(objExceptio.Message);
          }
    }
