    Image image = myImages[a-1];
    pictureBox1.Image = image;
    pictureBox8.Image = image;
    // special cases
    if (a == 1)
    {
        pictureBox2.Image = image;
        pictureBox11.Image = image;
        pictureBox9.Image = image;
    }
    if (a >= 1 && a <= 3)
    {
        pictureBox10.Image = image;
    }
