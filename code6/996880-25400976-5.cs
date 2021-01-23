    var image = new ImageEntity(){
       Content  = imageToByteArray(image)
    }
    _Context.Images.Add(image);
    _Context.SaveChanges();
