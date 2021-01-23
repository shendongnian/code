    public int displayImageIndex()
    {
        //access all images in list
        for (int i = 0; i < imagePaths.Count; ++i)
        {
            //matches image in picturebox
            if (picboxImage.ImageLocation == imagePaths[i])
            {
                //get index of image
                return i;
            }
        }
        return 0;
    }
