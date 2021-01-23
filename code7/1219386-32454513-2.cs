    byte[] bgImg = ???; // your code to fetch the bytes from the DB
    Image imgFromDb;
    using (MemoryStream ms = new MemoryStream(bgImg))
    using (Image tmpImg = Image.FromStream(ms))
    {
        // Needs to be wrapped in "new Bitmap(Image img)" constructor to avoid
        // the image being linked to and depending on the input stream.
        imgFromDb = new Bitmap(tmpImg);
    }
    picBox1.Image = imgFromDb;
