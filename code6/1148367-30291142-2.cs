    //using System.IO;
    string path = Path.Combine(@"\\BEHZAD-PC\foodimage", label1.Text, ".jpg");
    if (File.Exists(path)
    {
        pictureBox1.ImageLocation = path;
    }
