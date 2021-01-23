    public Form1()
    {
        InitializeComponent();
        this.button3.Click += button3_Click;
        this.FormClosing += Form1_FormClosing;
    }
    private void button3_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = MessageBox.Show(this, "Do you really want to quit?", 
                "Quit?", MessageBoxButtons.YesNo) != DialogResult.Yes;
    }
    
