    public Form1()
    {
        InitializeComponent();
        listView1.View = View.Details;
        listView1.FullRowSelect = true;
        listView1.Columns.Add("Problems", 80);
        listView1.Columns.Add("Data", 120);
        listView1.Columns.Add("Registry Key", 130);
        listView1.Columns.Add("users", 80);
        Thread childThread = new Thread(getlist);
        childThread.Start();
    }
    public void getlist()
    {
        add("a", "b", "c", "d");
    }
    public void add(string prob, string reg, string data, string user)
    {
        String[] row = { prob, reg, data, user };
        ListViewItem item = new ListViewItem(row);
        
        if (listView1.InvokeRequired)
        {
             listView1.Invoke(new MethodInvoker(delegate
             {
                 listView1.Items.Add(item);
                 item.Checked = true;
             }));
        }   
        else
        {
            listView1.Items.Add(item);
            item.Checked = true;
        } 
    
    }
