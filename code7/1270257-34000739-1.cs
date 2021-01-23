    // Define the size of our viewport using arbitary world coordinates
    var viewportSize = new SizeF(10, 10);
    // Create a new bitmap image that is 500 by 500 pixels
    using (var bmp = new Bitmap(500, 500, PixelFormat.Format32bppPArgb))
    {
        // Create graphics object to draw on the bitmap
        using (var g = Graphics.FromImage(bmp))
        {
            // Set up transformation so that drawing calls automatically convert world coordinates into bitmap coordinates
            g.TranslateTransform(0, bmp.Height * 0.5f - 1);
            g.ScaleTransform(bmp.Width / viewportSize.Width, -bmp.Height / viewportSize.Height);
            g.TranslateTransform(0, -viewportSize.Height * 0.5f);
            // Create pen object for drawing with
            using (var redPen = new Pen(Color.Red, 0.01f)) // Note that line thickness is in world coordinates!
            {
                // Randomization
                var rand = new Random();
                // Draw a 10x10 grid of vectors
                var a = new Vector();
                for (a.X = 0.5; a.X < 10.0; a.X += 1.0)
                {
                    for (a.Y = 0.5; a.Y < 10.0; a.Y += 1.0)
                    {
                        // Connect the center of this cell to a random point inside the cell
                        var offset = new Vector(rand.NextDouble() - 0.5, rand.NextDouble() - 0.5);
                        var b = a + offset;
                        g.DrawLine(redPen, a.ToPointF(), b.ToPointF());
                    }
                }
            }
        }
        // Save the bitmap and display it
        string filename = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "c#test.png");
        bmp.Save(filename, ImageFormat.Png);
        System.Diagnostics.Process.Start(filename);
    }
