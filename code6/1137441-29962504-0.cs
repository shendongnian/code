    public Boolean saveRotateImg(string path) 
    {
        string new_path="/Job_Files/"+Job_ID+"/"+GroupName+"/Images/"+path;
        // Load the image from the original path
        using (Image image = Image.FromFile(path)) 
        {
            //rotate the picture by 90 degrees and re-save the picture as a Jpeg
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            System.IO.File.Delete(path);
            // Save the image to the new_path
            image.Save(new_path, System.Drawing.Imaging.ImageFormat.Jpeg);
            image.Dispose();
        }
    }
