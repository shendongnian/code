    public Form1()
    {
        InitializeComponent();
        btnAdd.Click += btnAdd_Click;
        btn1.Click += btnAdd_Click;
        btn2.Click += btnAdd_Click;
    }
    void btnAdd_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Hello world");
    }
