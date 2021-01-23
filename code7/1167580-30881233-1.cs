        // Extension to save stream
        public static void CopyTo(this System.IO.Stream src, System.IO.Stream dest)
        {
            if (src == null)
                throw new System.ArgumentNullException("src");
            if (dest == null)
                throw new System.ArgumentNullException("dest");
            System.Diagnostics.Debug.Assert(src.CanRead, "src.CanRead");
            System.Diagnostics.Debug.Assert(dest.CanWrite, "dest.CanWrite");
            int readCount;
            var buffer = new byte[8192];
            while ((readCount = src.Read(buffer, 0, buffer.Length)) != 0)
                dest.Write(buffer, 0, readCount);
        }
          
