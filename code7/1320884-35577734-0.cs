    public BookManager()
    {
        InitializeComponent();
        ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadBooks);
        Thread t = new Thread(pts);
        t.Start();
    }
    public void LoadBooks(object state)
    {
        ImageList myImageList1 = null;
        Invoke(new Action(() =>
        {
            listView1.Clear();
            myImageList1 = new ImageList();
            myImageList1.ColorDepth = ColorDepth.Depth32Bit;
            listView1.LargeImageList = myImageList1;
            listView1.LargeImageList.ImageSize = new System.Drawing.Size(80, 80);
        }));
        MySqlConnection connection = null;
        try
        {
            connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "Select * from booktable";
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                byte[] byteBLOBData = (byte[])ds.Rows[i]["bookphoto"];
                var stream = new MemoryStream(byteBLOBData);
                Image bookimages = Image.FromStream(stream);
                Invoke(new Action(() =>
                {
                    myImageList1.Images.Add(bookimages);
                    ListViewItem lsvparent = new ListViewItem();
                    lsvparent.Text = ds.Rows[i]["booktitle"].ToString();
                    listView1.Items.Add(lsvparent.Text, i);
                }));
            }
        }
        finally
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
