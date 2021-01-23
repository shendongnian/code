     async public static Task<BitmapImage> GetImageFromZipEntry(ZipArchiveEntry zipentry)
        {
            //for extracting image inside a zip as bitmapimage
            BitmapImage tm = new BitmapImage();
            try {
                if (zipentry != null)
                {
                    using (Stream imstream = zipentry.Open())
                    {
                       
                        using (MemoryStream immemorystream = new MemoryStream((int)zipentry.Length))
                        {
                            
                            await imstream.CopyToAsync(immemorystream);
                            using (var sourceStream = new MemoryStream(immemorystream.ToArray()))
                            {
                                await tm.SetSourceAsync(sourceStream.AsRandomAccessStream());
                             
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                tm = null;
            }
            return tm;
           
        }
 
