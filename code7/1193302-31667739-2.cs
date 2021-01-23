    private void Form1_Shown(object sender, EventArgs e)
    {
        var frame1 = pictureBox2.BackgroundImage;
        var frame2 = pictureBox3.BackgroundImage;
        while(true)
        {
            pictureBox1.BackgroundImage = frame1;
            Application.DoEvents(); // give the thread room to run background tasks
            pictureBox1.BackgroundImage = frame2;
            Application.DoEvents(); // give the thread room to run background tasks
        }
    }
