    public Form1()
    {
        InitializeComponent();
        // You should first subscribe the same handler to each button's click event:
        btnAdd.Click += btnAdd_Click;
        btn1.Click += btnAdd_Click;
        btn2.Click += btnAdd_Click;
    }
    void btnAdd_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Hello world");
    }
