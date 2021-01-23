    public static Picture UpdatePictureViews(int userID, int picture)
    {
        DBContext db = new DBContext();
    
        var picture =  (from p in db.Pictures
                        where userID == p.UserID && picture == p.Url
                        select p).First();
        if(PictureViewCounter(picture, pictureArray, pictureUrl))
        {
            picture.Views++;
            db.SaveChanges();
        }
    }
    
    public static bool PictureViewCounter(Picture picture, List<int> pictureArray, int pictureUrl)
    {
        //In here basically return true if you want to increase the view count
        if (pictureArray == null)
        {
            //Automatically +1 picture views
            return true;
        }
        else
        {
            int result = pictureArray.Find(pic => pic == pictureUrl);
            //if result == 0 increase picture views by 1
            return true;
        }
    }
