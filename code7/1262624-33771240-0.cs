    using (Graphics g = Graphics.FromImage(bmp_merged))
    {
        angle = 15;
    
        bw2 = bmp_1.Width / 2f;
        bh2 = bmp_1.Height / 2f;
    
        g.TranslateTransform(bw2, bh2);
        g.RotateTransform(angle);
        g.TranslateTransform(-bw2, -bh2);
        g.DrawImage(bmp_1, 0, 0);
        angle = 35;
    
        bw2 = bmp_2.Width / 2f;
        bh2 = bmp_2.Height / 2f;
    
        g.ResetTransform();
        g.TranslateTransform(bw2, bh2);
        g.RotateTransform(angle);
        g.TranslateTransform(-bw2, -bh2);
        g.DrawImage(bmp_2, 0, 0);
    }
