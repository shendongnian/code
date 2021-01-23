       using (newBitmap.GetBitmapContext())
       {
           for (int i = 0; i < scrBitmap.PixelWidth; i++)
           {
               for (int j = 0; j < scrBitmap.PixelHeight; j++)
               {
                   actualColor = scrBitmap.GetPixel(i, j);
                   // > 150 because.. Images edges can be of low pixel col
                   if (actualColor.A > 0)
                       newBitmap.SetPixel(i, j, (Color)newColor);
                   else
                       newBitmap.SetPixel(i, j, actualColor);
                   //get the pixel from the scrBitmap image             
               }
           }
       }
