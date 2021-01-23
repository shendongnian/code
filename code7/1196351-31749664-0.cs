    //Create an image from the posted file's stream
    Bitmap image = new Bitmap(UploadPic.PostedFile.InputStream);
    Bitmap picture = new Bitmap(ListBox1.SelectedItem.Value);
    image = ResizeImage(image, picture.Width, picture.Height);
    image.Save("~/Resources/" + Path.GetFileName(ListBox1.SelectedItem.Value));
