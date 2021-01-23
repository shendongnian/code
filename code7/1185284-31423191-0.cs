                Bitmap newImage = new Bitmap(newWidth, newHeight);
                string path = ConfigurationManager.AppSettings["ImgBaseAddress"].ToString();
                System.Drawing.Image srcImage = System.Drawing.Image.FromFile(path+"/"+imageName));
                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.HighQuality;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
    
                }
                    MemoryStream ms = new MemoryStream();
                    newImage.Save(ms, ImageFormat.Gif);
                    var base64Data = Convert.ToBase64String(ms.ToArray());
                    return "data:image/gif;base64," + base64Data;
                }
