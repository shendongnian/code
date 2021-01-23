    // Load two images from file to compare.
    // In practice, images can be loaded from anywhere,
    // even from the designer.
    var image1 = new ComparableImage()
    {
        Image = Image.FromFile("bitmap1.bmp")
    };
    var image2 = new ComparableImage()
    {
        Image = Image.FromFile("bitmap2.bmp")
    };
            
    // Create two forms that have picture boxes:            
    var formA = new ComparableImageForm()
    {
        Image = image1
    };
    var formB = new ComparableImageForm()
    {
        Image = image2
    };
    // Perform the check to see if they are equal:
    if (formA.Image.Equals(formB.Image))
    {
        MessageBox.Show("The images are indeed equal.");
    }
    else
    {
        MessageBox.Show("The images are NOT equal.");
    }
    // Since images are compared based on their SHA1 hash, 
    // it does not matter where the image comes from as long
    // as the data is the same.  Here, we are loading another
    // copy of 'bitmap1.bmp':
    var anotherImage = new ComparableImage()
    {
        Image = Image.FromFile("bitmap1.bmp")
    };
    // The following statement will evaluate as true:
    bool isEqual = (anotherImage.Equals(image1));
