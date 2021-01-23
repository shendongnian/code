    private void button1_Click(object sender, EventArgs e)
    {
    	var img = _imageService.GetImage(textBox1.Text);
    
    	pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
    	pictureBox1.LoadAsync(img.Url);
    	label1.Text = img.Title;
    }
