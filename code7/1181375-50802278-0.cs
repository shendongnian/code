    private static bool CompareImages(string source, string expected)
    {
        var image1 = new Bitmap($".\\{source}");
        var image2 = new Bitmap($".\\Expected\\{expected}");
    
        var converter = new ImageConverter();
        var image1Bytes = (byte[])converter.ConvertTo(image1, typeof(byte[]));
        var image2Bytes = (byte[])converter.ConvertTo(image2, typeof(byte[]));
    
        // ReSharper disable AssignNullToNotNullAttribute
        var same = image1Bytes.SequenceEqual(image2Bytes);
        // ReSharper enable AssignNullToNotNullAttribute
        return same;
    }
