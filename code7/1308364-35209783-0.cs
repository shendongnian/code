    switch (Path.GetExtension(fd.FileName).ToUpper())
            {
                case ".BMP":                        
                    ((System.Drawing.Image)epiPictureBoxC1.Image).Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    break;
                case ".JPG":
                    ((System.Drawing.Image)epiPictureBoxC1.Image).Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                case ".PNG":
                    ((System.Drawing.Image)epiPictureBoxC1.Image).Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                default:
                    break;
            }
