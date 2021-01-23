    using (var tile = new Bitmap(tilePart.Width, tilePart.Height))
    {
      try
      {
          BitmapData srcData = sourceImage.LockBits(tilePart, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
          BitmapData dstData = tile.LockBits(new Rectangle(0, 0, tile.Width, tile.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
          unsafe
          {
              byte* dstPointer = (byte*)dstData.Scan0;
              byte* srcPointer = (byte*)srcData.Scan0;
              for (int i = 0; i < tilePart.Height; i++)
              {
                  for (int j = 0; j < tilePart.Width; j++)
                  {
                      dstPointer[0] = srcPointer[0]; // Blue
                      dstPointer[1] = srcPointer[1]; // Green
                      dstPointer[2] = srcPointer[2]; // Red
                      dstPointer[3] = srcPointer[3]; // Alpha
                      srcPointer += BytesPerPixel;
                      dstPointer += BytesPerPixel;
                  }
                  srcPointer += srcStrideOffset + srcTileOffset;
                  dstPointer += dstStrideOffset;
              }
          }
          tile.UnlockBits(dstData);
          aSourceImage.UnlockBits(srcData);
          tile.Save(path);
      }
      catch (InvalidOperationException e)
      {
      }
    }
