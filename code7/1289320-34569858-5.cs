    public Form1()         
    {        
        InitializeComponent(); 
        var publisherLogger = new PublisherLogger(); //or inject it
        publisherLogger.LogMessages += msg =>
        {
            //add msg to list view
            ListViewItem item = new ListViewItem { Text = DateTime.Now.ToString()     };
            item.SubItems.Add(text);
            _listView.Items.Add(ret);
        };
    }
