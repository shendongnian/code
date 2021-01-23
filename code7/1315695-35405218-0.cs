    string imageCname = kinectId + "_" + dateTimes[i] + ".jpg";
    imageCt = imageCs[i];
    ZipArchiveEntry zipEntryC = zipArchive.CreateEntry(imageCname);
    
    using (var stream = new MemoryStream())
    {
      using (var zipEntryStream = zipEntryC.Open())
      {
        System.Drawing.Image userImage = imageCt.ToBitmap();
        userImage.Save(stream, ImageFormat.Jpeg);
        stream.Seek(0, SeekOrigin.Begin);
        stream.CopyTo(zipEntryStream);
      }
    }
    Console.WriteLine("Flushing rgb " + i + " of " + clouds.Count);
