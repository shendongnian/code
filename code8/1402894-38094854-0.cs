    public bool IsValidImageFile (string imageFile)
    {
        try
        {
            // the using is important to avoid stressing the garbage collector
            using (var test = System.Drawing.Image.FromFile(imageFile))
            {
                 // image has loaded and so is fine
                 return true;
            }
        }
        catch
        {
            // technically some exceptions may not indicate a corrupt image, but this is unlikely to be an issue
            return false;
        } 
    }
