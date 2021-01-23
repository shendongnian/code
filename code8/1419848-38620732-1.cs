    public Form1()
    { 
        InitializeComponent();
        try
          { string n = wc.DownloadString("https://xxxxx?dl=1");
        NEWS.Text = n;
          }
        catch(Exception objException)
          { System.Diagnostics.WriteLine(objExceptio.Message);
          }
    }
