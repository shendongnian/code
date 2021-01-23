    public Form1()         
    {        
        InitializeComponent(); 
        var consoleLogger = new ConsoleLogger(); //or inject it
        consoleLogger.LogMessages += msg =>
        {
            //add msg to list view
            ListViewItem item = new ListViewItem { Text = DateTime.Now.ToString()     };
            item.SubItems.Add(text);
            _listView.Items.Add(ret);
        };
    }
