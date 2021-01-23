    public Form1()
    {
        InitializeComponent();
        timer1.Interval = 3000;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {           
        Random rnd = new Random();
        int i = rnd.Next(0, listBox1.Items.Count - 1);
        textBox2.Text = listBox1.Items[i].ToString();            
    }
