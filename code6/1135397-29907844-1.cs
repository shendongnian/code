    Image image;
    using (Stream stream = File.OpenRead(path))
    {
        image = System.Drawing.Image.FromStream(stream);
    }
    pictureBox.Image = image;
    File.Delete("e:\\temp\\copy1.png");  //works
