    else 
    {
      var Image = db.ImageAttributes.Where(r => r.DisplayDirection == parameter).FirstOrDefault();
    var base64Image = Convert.ToBase64String(Image.Image);
    var byteArray = Convert.FromBase64String(base64Image);
    return File(byteArray , "image/png", "image.png");
                        
    }
