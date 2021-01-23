    Int32 s32MemID;
    Bitmap bm;
    string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    for (int i = 1; i <= frameno; i++)
    {
        try
        {
            Camera.Memory.GetActive(out s32MemID);
            Camera.Memory.CopyToBitmap(s32MemID, out bm);
            bm.RotateFlip(RotateFlipType.Rotate90FlipNone);
            bm.Save(Path.Combine(targetPath, "capture" + (i.ToString().PadLeft('0', 3)) + ".bmp"), ImageFormat.Bmp); 
        }
        finally 
        {
            if (bm != null) 
            {
                bm.Dispose();
                bm = null;
            }
        }
        Thread.Sleep(delay);
    }
