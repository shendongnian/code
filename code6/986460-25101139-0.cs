    var picture = media.Pictures
                       .FirstOrDefault(p => p.Name.Contains("the_name.jpg"));
    
    if (picture != null)
    {
        // Picture found
    	var originalImage = picture.GetImage();
    	// do something with original image
    }
