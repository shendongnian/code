    public Form1()
    {
        InitializeComponent();
        this.button3.Click += button3_Click;
    }
    private void button3_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
    
