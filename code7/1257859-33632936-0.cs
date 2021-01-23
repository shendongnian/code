    var image = new Bitmap(str);
    var ratio = (double)1110 / image.Width;
    var newWidth = (int)(image.Width * ratio);
    var newHeight = (int)(image.Height * ratio);
    var newImage = new Bitmap(newWidth, newHeight);
    Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
    var bmp = new Bitmap(newImage);
    if(bmp.Height > 300){
    //Resize again using crop, like you did in your original code.
    }
