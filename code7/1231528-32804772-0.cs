        private static byte[] ReduceSize(FileStream stream, int maxWidth, int maxHeight)
        {
            Image source = Image.FromStream(stream);
            double widthRatio = ((double)maxWidth) / source.Width;
            double heightRatio = ((double)maxHeight) / source.Height;
            double ratio = (widthRatio < heightRatio) ? widthRatio : heightRatio;
            Image thumbnail = source.GetThumbnailImage((int)(source.Width * ratio), (int)(source.Height * ratio), AbortCallback, IntPtr.Zero);
            using (var memory = new MemoryStream())
            {
                thumbnail.Save(memory, source.RawFormat);
                return memory.ToArray();
            }
        }
