    //using System.IO;
    string path = Path.Combine(@"C:\foodimage", label1.Text, ".jpg");
    if (File.Exists(path)
    {
        pictureBox1.Image = Image.FromFile(path);
    }
