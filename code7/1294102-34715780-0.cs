    private void InvertZ(Image _image)
    {            
        byte[] array =imageToByteArray(_image);
        int pageSize = _Image.Size.Y * _Image.Size.X;
        for (int z = 0; z < _image.Size.Z/2; z++)
        {
            int level = z * pageSize;
            int dstLevel = (_image.Size.Z - z - 1) * pageSize;
            for (int x = 0; x < _image.Size.X; x++)
            {
                int Row = x*_Image.Size.Y;
                int RowOnLevel = level + Row ;
                int dstRowOnLevel = dstLevel + xRow;
                for (int y = 0; y < _image.Size.Y; y++)
                {
                    int srcIndex = RowOnLevel + y;
                    int destIndex = dstRowOnLevel + y;
                    byte tmpDest = array[destIndex];
                    array[destIndex] = array[srcIndex];
                    array[srcIndex] = tmpDest;
                }
            }
        }
        return byteArrayToImage(array);
    }
    public Image byteArrayToImage(byte[] byteArrayIn)
    {
        MemoryStream ms = new MemoryStream(byteArrayIn);
        Image returnImage = Image.FromStream(ms);
        return returnImage;
    }
    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
        MemoryStream ms = new MemoryStream();
        imageIn.Save(ms,System.Drawing.Imaging.ImageFormat.Gif);
        return  ms.ToArray();
    }
