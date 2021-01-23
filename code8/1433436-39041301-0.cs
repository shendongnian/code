        public static class ImageLoader
        {
            // This isn’t going to help much – you’ll run out of memory anyway on very large images – but if you are keeping several in memory it might …
            public const int MaximumImageDimension = 10000;
    
            /// 
            /// Method to safely load an image from a file without leaving the file open, 
            /// also gets the size down to a manageable size in the case of HUGE images
            /// 
            /// An Image – don’t forget to dispose of it later
            public static Image LoadImage(string filePath)
            {
                try
                {
                    FileInfo fi = new FileInfo(filePath);
    
                    if (!fi.Exists) throw new FileNotFoundException("File not found.");
                    if (fi.Length == 0) throw new FileNotFoundException("File zero lenght");
    
                    // Image.FromFile is known to leave files open, so we use a stream instead to read it
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        if (!fs.CanRead) throw new FileLoadException("Can't read the file stream");
    
                        if (fs.Length == 0) throw new FileLoadException("File stream zero lenght");
    
                        using (Image original = Image.FromStream(fs))
                        {
                            // Make a copy of the file in memory, then release the one GDI+ gave us
                            // thus ensuring that all file handles are closed properly (which GDI+ doesn’t do for us in a timely fashion)
                            int width = original.Width;
                            int height = original.Height;
                            if (width == 0)
                                throw new DataException("Bad image dimension width=0");
                            if (height == 0) throw new DataException("Bad image dimension height=0");
    
                            // Now shrink it to Max size to control memory consumption
                            if (width > MaximumImageDimension)
                            {
                                height = height * MaximumImageDimension / width;
                                width = MaximumImageDimension;
                            }
                            if (height > MaximumImageDimension)
                            {
                                width = width * MaximumImageDimension / height;
                                height = MaximumImageDimension;
                            }
    
                            Bitmap copy = new Bitmap(width, height);
                            using (Graphics graphics = Graphics.FromImage(copy))
                            {
                                graphics.DrawImage(original, 0, 0, copy.Width, copy.Height);
                            }
                            return copy;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("File", filePath);
                    throw;
                }
            }
        }
