    public Form1()
    {
        InitializeComponent();
        this.MouseMove += new MouseEventHandler(Form1_MouseMove);
    }
    void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        int x = Cursor.Position.X;
        int y = Cursor.Position.Y;
        textBox1.Text = "X: " + x + " Y: " + y + "";
    }
