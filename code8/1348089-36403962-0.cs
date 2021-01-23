    class bitmapCompare
    {
        public enum CompareResult
        {
            ciCompareOk,
            ciPixelMismatch,
            ciSizeMismatch
        };
        public static CompareResult Compare(bool useHash, Bitmap bmp1, Bitmap bmp2, out double err, out Bitmap diff)
        {
            CompareResult cr = CompareResult.ciCompareOk;
            int er = 0;
            err = 0;
            diff = new Bitmap(bmp1.Width, bmp1.Height);
            //Test to see if we have the same size of image
            if (bmp1.Size != bmp2.Size)
            {
                cr = CompareResult.ciSizeMismatch;
                err = 100;
            }
            else
            {
                //Convert each image to a byte array
                System.Drawing.ImageConverter ic =
                       new System.Drawing.ImageConverter();
                byte[] btImage1 = new byte[1];
                btImage1 = (byte[])ic.ConvertTo(bmp1, btImage1.GetType());
                byte[] btImage2 = new byte[1];
                btImage2 = (byte[])ic.ConvertTo(bmp2, btImage2.GetType());
                //Compute a hash for each image
                SHA256Managed shaM = new SHA256Managed();
                byte[] hash1 = shaM.ComputeHash(btImage1);
                byte[] hash2 = shaM.ComputeHash(btImage2);
                //Compare the hash values
                if (useHash)
                {
                    for (int i = 0; i < hash1.Length && i < hash2.Length; i++)
                    {
                        if (hash1[i] != hash2[i])
                        {
                            er++;
                            cr = CompareResult.ciPixelMismatch;
                        }
                    }
                }
                else
                {
                    int totalPixels = 0;
                    er = 0;
                    for (int x = 0; x < bmp1.Width; x++)
                    {
                        for (int y = 0; y < bmp1.Height; y++)
                        {
                            totalPixels++;
                            if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                            {
                                
                                diff.SetPixel(x, y, Color.Black);
                                er++;
                                cr = CompareResult.ciPixelMismatch;
                            }
                            else
                                diff.SetPixel(x, y, Color.White);
                        }
                    }
                    System.Diagnostics.Debug.WriteLine("Total pixels:{0}", totalPixels);
                    System.Diagnostics.Debug.WriteLine("Diff pixels:{0}", er);
                    if (er > 0)
                        err = (double)er / ((double)bmp1.Height * (double)bmp1.Width);
                    else
                        err = 0;
                    if (err > 0) err = Math.Round(err*100, 1);
                    if (err > 100) err = 100;
                    
                }
            }
            return cr;
        }
    
