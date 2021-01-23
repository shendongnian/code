    foreach (string strJPGImagePath in strarrFileList) {
      Bitmap bmpDest;
      using(Bitmap bmpOrig = new Bitmap(strJPGImagePath)) {
        bmpDest = new Bitmap(bmpOrig, new Size(100, 200));
      }
      bmpDest.Save(strJPGImagePath, jgpEncoder, myEncoderParameters);
      bmpDest.Dispose();
    }
