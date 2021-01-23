    public Form1()
    {
        InitializeComponent();
        // Set these 2 properties in the designer, not here.
        this.KeyPreview = true;
        this.KeyDown += Form1_KeyDown;
    }
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        int x = pictureBox1.Location.X;
        int y = pictureBox1.Location.Y;
        if (e.KeyCode == Keys.D) x += 1;
        else if (e.KeyCode == Keys.A) x -= 1;
        else if (e.KeyCode == Keys.W) y -= 1;
        else if (e.KeyCode == Keys.S) y += 1;
        pictureBox1.Location = new Point(x, y);
    }
