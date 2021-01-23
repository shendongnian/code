    public byte[] ConvertToBytes(HttpPostedFileBase image)
    {
       return image.InputStream.StreamToByteArray();
    }
    public static byte[] StreamToByteArray(this Stream input)
    {
        input.Position = 0;
        using (var ms = new MemoryStream())
        {
            int length = System.Convert.ToInt32(input.Length);
            input.CopyTo(ms, length);
            return ms.ToArray();
        }
    }
