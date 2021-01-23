    private void LoadNewImage(string path)
    {
        var oldImage = picImages.Image;
        picImages.Image = Image.FromFile(dir+"\\"+curitem);
        if(oldImage!= null)
        {
            oldImage.Dispose();
        }
    }
