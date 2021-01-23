    private WebClient _webClient;
    public Form1()
    {
        InitializeComponent();
        _webClient = new WebClient();
        _webClient.DownloadFileCompleted += (s, e) =>
          {
            try
            {
               if (e.Cancelled) 
                 return;
               
               //do something with your file
            }
            finally
            {
              _webClient.Dispose(); 
            }
          };
        _webClient.DownloadFileAsync(...);
    }
     
    private void button1_Click(object sender, EventArgs e)
    {
        _webClient.CancelAsync();
    }
