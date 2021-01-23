    public Form1()
    {
        InitializeComponent();
        panel1.MouseMove += panel1_MouseMove;
    }
    void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        lbl.Location = e.Location;
    }
