    for (int i = 0; i < numofrows; i++)
    {
        byte[] fetchedBytes = (byte[])Table.Rows[i]["faceimg"];
        MemoryStream stream = new MemoryStream(fetchedBytes);
        bitimage = new Bitmap(stream);
        Image<Gray, byte> img = new Emgu.CV.Image<Gray, Byte>(bitimage )
        Image<Gray, byte> resizedImage = img.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
        FaceImg.Add(resizedImage);
        String faceName = (String)Table.Rows[i]["facename"];
        FaceName.Add(faceName);
    }
