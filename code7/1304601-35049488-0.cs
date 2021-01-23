    [ActionName("GetImage")]
    public string GetImage(string base64String, string imgName)
    {
        try
        {
    
            using (PhNetworkEntities context = new PhNetworkEntities())
            {
                pic pic = new pic();
                pic.path = new string('*', 502); // MODIFY!! Always FAILS!!!
                pic.picname = imgName;
                context.pics.Add(pic);
                context.SaveChanges();
                return "Success";
            }
    
        }
        catch (DbEntityValidationException ex)
        {
           // same as Question...
        }
    }
