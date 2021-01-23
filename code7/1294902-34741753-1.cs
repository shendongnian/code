    private void button1_Click(object sender, EventArgs e)
    {
         string title = string.Empty;
    
         pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
         pictureBox1.LoadAsync(_imageService.GetImage(textBox1.Text, out title));
         label1.Text = title;
    }
