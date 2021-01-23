    public static string UnZip(string value)
    {
        // Removing brackets from string
        value = value.TrimStart('[');
        value = value.TrimEnd(']');
        //Transform string into byte[]
        string[] strArray = value.Split(',');
        byte[] byteArray = new byte[strArray.Length];
        for (int i = 0; i < strArray.Length; i++)
        {
            byteArray[i] = unchecked((byte)Convert.ToSByte(strArray[i]));
        }
        //Prepare for decompress
        using (System.IO.MemoryStream output = new System.IO.MemoryStream())
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArray))
            using (System.IO.Compression.GZipStream sr = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress))
            {
                sr.CopyTo(output);
            }
            string str = Encoding.UTF8.GetString(output.GetBuffer(), 0, (int)output.Length);
            return str;
        }
    }
