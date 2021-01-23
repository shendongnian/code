        public static Bitmap ByteToImage(byte[] blob)
        {
            try
            {
                /// Write memory stream
                MemoryStream mStream = new MemoryStream();
                byte[] pData = blob;
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                Bitmap bm = new Bitmap(mStream, false);
                _Height = Convert.ToInt32(bm.Height);
                _Width = Convert.ToInt32(bm.Width);
                mStream.Dispose();
                return bm;
            }
            catch
            {
                throw;
            }
        }
