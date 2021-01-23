    foreach (Panel px in new Panel[] { p1, p2, p3, p4 } )
        using (Bitmap bmp = new Bitmap(pX.ClientSize.Width, pX.ClientSize.Height))
        {
            pX.DrawToBitmap(bmp, pX.ClientRectangle);
            bmp.Save(somefolder + pX.Name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
