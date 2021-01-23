    private void Form1_Load(object sender, EventArgs e)
    {  
        RapidPictureBox pictureBox1 = new RapidPictureBox();
        pictureBox1.Dock = DockStyle.Fill;
        Controls.Add(pictureBox1);
        pictureBox1.block = GetOverlappedImages(new Bitmap("3.png"),new Bitmap("2.png")); //draw on the initial one.
    }
