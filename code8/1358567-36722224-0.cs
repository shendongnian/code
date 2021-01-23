    public byte[] ImageControlToByteArray(Image image)
    {
            try
            {
                // Attempt to find the Image that the control points to
                // and read all of it's bytes
                return File.ReadAllBytes(Server.MapPath(image.ImageUrl));
            }
            catch (Exception ex)
            {
                // Uh oh, there was a problem reading the file
                return new byte[0];
            }
    }
