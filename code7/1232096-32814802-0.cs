    private void button1_Click(object sender, EventArgs e)
    {
        var randomFilename = "pic" + RandomString1(5) + ".png";
        System.Drawing.Image image = System.Drawing.Image.FromFile("Pic.bmp");
        image.Save(randomFilename, System.Drawing.Imaging.ImageFormat.Png);
        UploadImage("ftp://example.com", "uname", "pword", randomFilename);
    }
