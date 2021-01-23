        byte[] bgImg = ???; // your code to fetch the bytes from the DB
        Image imgFromDb;
        using (MemoryStream ms = new MemoryStream(bgImg))
        {
            imgFromDb = Image.FromStream(ms);
        }
        picBox1.Image = imgFromDb;
