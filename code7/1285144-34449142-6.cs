    public Form1()
    {
        InitializeComponent();
        // your other init code here
        Controls.Add(pan);  // add only once
        pan.BringToFront();
        pan.Hide();         // and hide or show
        this.DoubleDuffered = true  // !!
    }
    private void pictureBox1_MouseLeave(object sender, EventArgs e)
    {
        pan.Hide();         // hide or show
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        pan.Location = pictureBox1.PointToClient(Cursor.Position);
        pictureBox1.Refresh();  // !!
        Refresh();              // !!
    }
    private void pictureBox1_MouseEnter(object sender, EventArgs e)
    {
        pan.Height = 200;
        pan.Width = 100;
        pan.BackColor = Color.Blue;
        pan.Location = pictureBox1.PointToClient(Cursor.Position);
        pan.Show();        // and hide or show
    }
