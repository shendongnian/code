    for (int i = 0; i < numofrows; i++)
    {
        byte[] fetchedBytes = (byte[])Table.Rows[i]["faceimg"];
        MemoryStream stream = new MemoryStream(fetchedBytes);
        bitimage = new Bitmap(stream);
        Image<Gray, byte> resizedImage = bitimage.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
        FaceImg.Add(new Emgu.CV.Image<Gray, Byte>(resizedImage));
        String faceName = (String)Table.Rows[i]["facename"];
        FaceName.Add(faceName);
    }
