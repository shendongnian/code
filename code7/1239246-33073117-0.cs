    public ActionResult AddtoCart(string selPhoto, string preview_photo)
            {
    
        string[] values = selPhoto.Split(',');
        string[] photo = preview_photo.Split(',');
        foreach (var item in values)
        {
            if (photo.Contains(item))
            {
              // do action item in second array
            }
    
            else
            {
             //do action item not in second array
            }
        }
    }
