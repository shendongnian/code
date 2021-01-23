    Bitmap i = AForge.Imaging.Image.FromFile("C:/Users/KuroTenshi/WD/normalblue/07_bloom_doublemetaldoor_d_high_n.bmp");
            ExtractChannel filterR = new ExtractChannel(RGB.R);
            Bitmap r = filterR.Apply(i);
            Bitmap j = AForge.Imaging.Image.Clone(i);
            ExtractChannel filterR2 = new ExtractChannel(RGB.R);
            ExtractChannel filterB2 = new ExtractChannel(RGB.B);
            ExtractChannel filterA2 = new ExtractChannel(RGB.A);
            Bitmap r2 = filterR2.Apply(j);
            Bitmap b2 = filterB2.Apply(j);
            Bitmap a2 = filterA2.Apply(j);
            a2 = r;
            Bitmap bmp = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            bmp.SetPixel(0, 0, Color.FromArgb(255, 255, 255));
            bmp = new Bitmap(bmp, i.Width, i.Height);          
            r2 = bmp;
            Bitmap bmp2 = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
    //Opening the normal map (RGB)
            Bitmap i = AForge.Imaging.Image.FromFile("C:/Users/KuroTenshi/WD/normalblue/07_bloom_doublemetaldoor_d_high_n.bmp");
            //Extract the red channel, that will be put in an alpha channel
            ExtractChannel filterR = new ExtractChannel(RGB.R);
            Bitmap r = filterR.Apply(i);
            //Clone the input image to have a base for the output (it's converted to ARGB)
            Bitmap j = AForge.Imaging.Image.Clone(i);
            //Extract channels to modify
            ExtractChannel filterR2 = new ExtractChannel(RGB.R);
            ExtractChannel filterB2 = new ExtractChannel(RGB.B);
            ExtractChannel filterA2 = new ExtractChannel(RGB.A);
            Bitmap r2 = filterR2.Apply(j);
            Bitmap b2 = filterB2.Apply(j);
            Bitmap a2 = filterA2.Apply(j);
            //Putting input's red channel into output's alpha channel
            a2 = r;
            //Creating a red Bitmap for the output's red channel
            Bitmap bmp = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            bmp.SetPixel(0, 0, Color.FromArgb(255, 0, 0));
            bmp = new Bitmap(bmp, i.Width, i.Height);
            
            r2 = bmp;
            //Creating a black Bitmap for the output's blue channel
            Bitmap bmp2 = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
            bmp2.SetPixel(0, 0, Color.FromArgb(0,0,0));
            bmp2 = new Bitmap(bmp2, i.Width, i.Height);
            b2 = bmp2;
            //Replace channels
            ReplaceChannel replaceFilter = new ReplaceChannel(RGB.A, a2);
            replaceFilter.ApplyInPlace(j);
            replaceFilter = new ReplaceChannel(RGB.R, r2);
            replaceFilter.ApplyInPlace(j);
            replaceFilter = new ReplaceChannel(RGB.B, b2);
            replaceFilter.ApplyInPlace(j);
            //Save output
            j.Save("C:/Users/KuroTenshi/WD/normalblue/07_bloom_doublemetaldoor_d_high_n2.bmp");
