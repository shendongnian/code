    public MainScreen()
    {
        InitializeComponent();
        KeyDown += new KeyEventHandler(MainScreen_KeyDown);
        if (characterCreated == false)
        {
            playGameBtn.ForeColor = Color.Gray;
        }
    }
    private void pictureBox1_Click(object sender, EventArgs e)
    {
         // REMOVE ALL THE CODE FROM THIS EVENT AND MOVE IT TO MainScreen_KeyDown  event
    }
    private void MainScreen_KeyDown(object sender, KeyEventArgs e)
    {
        int x = pictureBox1.Location.X;
        int y = pictureBox1.Location.Y;
        if (e.KeyCode == Keys.Right)
        {
            x += 2;
        }
        else if (e.KeyCode == Keys.Left) 
        {
            x -= 2;
        }
        else if (e.KeyCode == Keys.Up)
        {
            y += 2;
        }
        else if (e.KeyCode == Keys.Down)
        {
            y -= 2;
        }
        pictureBox1.Location = new System.Drawing.Point(x, y);
    }
