    using (WritablePixelCollection pc = img.GetWritablePixels(100, 100, 50, 50))
    {
      foreach (Pixel p in pc)
      {
        p.SetChannel(0, 255);
        p.SetChannel(1, 0);
        p.SetChannel(2, 0);
        pc.Set(p) // This will update the PixelCollection
      }
    }
