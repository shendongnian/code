    List<PictureBox> Layers = new List<PictureBox>();
    private void Form1_Load(object sender, EventArgs e)
    {
        Layers.Add(pBox0);
        setUpLayers(pBox0 , 20);  // stacking 20 layers onto the botton one
        timer1.Start();           // simulate changes
    }
