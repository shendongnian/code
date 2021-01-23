    bool IsOn = true;
    private void pictureBox1_Click(object sender, EventArgs e)
    {
        if(IsOn)
        {
          pictureBox1.Image = Image.FromFile("D:\\off.png"); 
          IsOn = false;
        } else {
          pictureBox1.Image = Image.FromFile("D:\\on.png");
          IsOn = true;
        } 
    }
