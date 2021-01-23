    var image = new ImageEntity()
    {
       Content = ImageToByteArray(image)
    };
    _context.Images.Add(image);
    _context.SaveChanges();
