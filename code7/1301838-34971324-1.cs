    int radius = 10; 
    Image img = new Bitmap("file_path.png");
    Bitmap image = new Bitmap(img, radius, radius);
    //arbitrary angle of 67
    try
    {
        image = AForge.Imaging.Image.Clone(image, PixelFormat.Format8bppIndexed);
        RotateBilinear ro = new RotateBilinear(67, true);
        image = ro.Apply(image);
    }
    catch (Exception e)
    { 
        Debug.WriteLine(string.Format("Caught Exception {0}\n{1}", e.GetType(), e.Message);
    } 
    Graphics g = e.Graphics;
    g.DrawImage(image, 100, 100);
