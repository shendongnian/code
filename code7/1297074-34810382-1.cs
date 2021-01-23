    public void Add(String screenShot, String versionId, String text)
        {
            String imgId = null;
    
            if(!String.IsNullOrEmpty(screenShot))
            {
                Byte[] data = Convert.FromBase64String(screenShot);
    
            // rest of code omitted
