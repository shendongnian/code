    public EventHandler SomeEvent { get; set; }
    public Form1()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Form2 f = new Form2();
        this.SomeEvent += new EventHandler(f.IncProgress);
        f.Show();
        for (int i = 0; i < 1000000; i++)
        {
            if (SomeEvent != null)
                SomeEvent(this, new EventArgs());
        }
        f.Close();
      
    }
