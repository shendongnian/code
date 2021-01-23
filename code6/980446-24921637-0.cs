    public byte[] FixImage(byte[] imageData,  int bitsPerPixel)
    {
        int bytesPerPixel = bitsPerPixel / 8;
        List<byte> data = new List<byte>();
        for (int i = 0; i < imageData.Length; i += 384 * bytesPerPixel)
        {
            data.AddRange(new byte[64*bytesPerPixel]);
            data.AddRange(imageData.Skip(i).Take(384 * bytesPerPixel));
            data.AddRange(new byte[64 * bytesPerPixel]);
        }
        return data.ToArray();
    }
