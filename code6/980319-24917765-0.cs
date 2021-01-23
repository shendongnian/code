    public static void UpdatePictureViewCounter(int userId, List<int> pictureArray, 
                                                int pictureUrl)
    {
        if (pictureArray == null || !pictureArray.Contains(pictureUrl))
        {
            // increment the view.
    
            using (var db = new PetscoveryDBContext())
            {
                var picture = (from p in db.Pictures where userID == 
                              p.UserID && pictureUrl == p.Url select p).First();
                ++picture.Views;
    
                db.SaveChanges();
            }
        }
    }
