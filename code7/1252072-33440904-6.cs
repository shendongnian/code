    string imageLocation = Application.StartupPath + @"\myImage.jpg"
    pictureBox1.Image.Save(imageLocation, ImageFormat.Jpeg);
    // declare bc like code above.
    bc.ImageLocation = imageLocation;
    // serialize bc.
