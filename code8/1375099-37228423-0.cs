    List<System.Drawing.Point> ycolo = new List<System.Drawing.Point>();
    for (int p = 5; p < FilteredImage.Width; p++)
    {
        for (int k = 5; k < FilteredImage.Height; k++)
        {
            ycolo.Add(new System.Drawing.Point(p, k));
            if (k == 10) { break; }
        }
        if (p == 20) { break; }
    }
    if (ycolo.Contains(new System.Drawing.Point(21, 11)))
    {
        MessageBox.Show("Im here");
    }
    else
    {
        MessageBox.Show("Im not here");
    }
