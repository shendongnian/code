        ...
            try
            {
            var data = UnicodeEncoding.ASCII.GetBytes(sw.ToString());
            using (Stream stream = new MemoryStream(data))
            {
                stream.Position = 0;
                bool res = this.UploadFile(stream, "OgrenciListesi.csv", "tmp");
            }
            }
            catch (Exception)
            {
                throw;
            }
        ...
