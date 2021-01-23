    var file = @"d:\pic\1.jpg";
    using (var s = new System.IO.FileStream(file, System.IO.FileMode.Open))
    {
        pictureBox1.Image = Image.FromStream(s);
    }
    System.IO.File.Delete(file);
