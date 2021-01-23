            Bitmap bmp;
            string ext = Path.GetExtension(path);
            if (ext == ".exe")
            {
                Icon ico = Icon.ExtractAssociatedIcon(path);
                bmp = ico.ToBitmap();
                ico.Dispose();
            }
            else
            {
                if (imageType.Contains(ext.Replace(".", "")))
                {
                    Image img = Image.FromFile(path);
                    bmp = new Bitmap(img, new Size(d.Width - 20, 80));
                    img.Dispose();
                }
                else
                {
                    Icon ico = GetLargeIconForExtension(ext);
                    bmp = ico.ToBitmap();
                    ico.Dispose();
                
                }
            
            }
