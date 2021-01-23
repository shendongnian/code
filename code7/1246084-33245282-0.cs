    public void addStamp(String originalImagePath, String stampImagePath,String outputPath)
            {   
                Image originalImage=Image.FromFile(originalImagePath);
                Image stampImage = Image.FromFile(stampImagePath);              
    
                Bitmap bitmap = new Bitmap(originalImage);
    
                Graphics gr = Graphics.FromImage(bitmap);
    
                gr.DrawImage(stampImage, new Point(0, 0));
    
                bitmap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);    
            }
