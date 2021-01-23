    Image newImage = Image.FromFile(newFileNamePath); 
    int newWidth = (int) (newImage.Width * (1 + ((double) percentageSize / 100)));
    int newHeight = (int) (newImage.Height * (1 + ((double) percentageSize / 100)));
    newImage.Dispose();
    Image anotherImage = ResizeImage(newFileNamePath, newWidth, newHeight))
    anotherImage.Save(directory + RESIZED_DIRECTORY + "\\" + newFileName, ImageFormat.Jpeg);
    anotherImage.Dispose();
