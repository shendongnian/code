            var bitData = image.LockBits(new Rectangle(Point.Empty,image.Size), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int numBytes = bitData.Stride * image.Height;
            byte[] rgbValues = new byte[numBytes];
            IntPtr ptr = bitData.Scan0;
            // copy the image into an array
            Marshal.Copy(ptr, rgbValues, 0, numBytes);
            for (int i = 3; i < rgbValues.Length; i+= 4)
            {
                var c = Color.FromArgb(rgbValues[i], rgbValues[i - 1], rgbValues[i - 2], rgbValues[i - 3]);
                if (histo.ContainsKey(c))
                    histo[c] = histo[c] + 1;
                else
                    histo.Add(c, 1);
            }
            image.UnlockBits(bitData);
