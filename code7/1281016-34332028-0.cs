    try
    {
        string[] images = { @"Resource\picture1", @"Resource\picture2" };
        this.pictureBox1.Image = Image.FromFile(images[0]);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
