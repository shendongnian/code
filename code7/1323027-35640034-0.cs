    // here you can use any image, I just read it in for testing..
    Bitmap bmp = (Bitmap)Bitmap.FromFile("D:\\xxx.png");
    // create a named image from it
    NamedImage ni = new NamedImage("test", bmp);
    // add it to the chart's collection of images
    chart1.Images.Add(ni);
    // now we can use it at any place we seemingly can only use a path:
    chart1.BackImage = "test";
