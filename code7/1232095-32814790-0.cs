    private void button1_Click(object sender, EventArgs e)
    {
    	string RndString = RandomString1(5);
    	System.Drawing.Image image = System.Drawing.Image.FromFile("Pic.bmp");
    	image.Save("Pic" + RndString + ".png", System.Drawing.Imaging.ImageFormat.Png);
    	UploadImage("ftp://example.com", "uname", "pword", "pic" + RndString + ".png");
    }
