    //Capture an image of your test control
    Bitmap testControlImage = yourUITestControl.CaptureImage() as Bitmap;
    // Get the color of a pixel you specify within the captured image.
    Color pixelColor = testControlImage.GetPixel(50, 50); 
    // Assert the pixel color
    Assert.AreEqual(pixelColor.ToString(), "Color [A=255, R=99, G=99, B=99]"); 
