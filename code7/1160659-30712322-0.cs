    static void Main(string[] args)
        {
            string imageFlePath = "d:\\1.jpg";
            BitmapDecoder decoder = null;
            BitmapFrame bitmapFrame = null;
            FileInfo originalImage = new FileInfo(imageFlePath);
            if (System.IO.File.Exists(imageFlePath))
            {
                using (Stream jpegStreamIn = System.IO.File.Open(imageFlePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    decoder = new JpegBitmapDecoder(jpegStreamIn, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                }
                bitmapFrame = decoder.Frames[0];
                Collection<System.Windows.Media.ColorContext> gdf = new Collection<System.Windows.Media.ColorContext>();
                ReadOnlyCollection<System.Windows.Media.ColorContext> dgfd = new ReadOnlyCollection<System.Windows.Media.ColorContext>(gdf);
                if (bitmapFrame != null)
                {
                    BitmapMetadata metaData = (BitmapMetadata)bitmapFrame.Metadata.Clone();
                    BitmapMetadata mData2 = new BitmapMetadata("jpg");
                    foreach (string key in metaData)
                    {
                        if (key == "/xmp")
                        {
                            BitmapMetadata subSrc = (BitmapMetadata)metaData.GetQuery(key);
                            BitmapMetadata subDest = new BitmapMetadata("xmp");
                            foreach (string subKey in subSrc)
                            {
                                if (subKey != "/xmpMM:History")
                                {
                                    var val = subSrc.GetQuery(subKey);
                                }
                            }
                            mData2.SetQuery(key, subDest);
                        }
                        else
                        {
                            mData2.SetQuery(key, metaData.GetQuery(key));
                        }
                    }
                    if (metaData != null)
                    {
                        metaData.SetQuery("System.Keywords", "Test");
                        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(bitmapFrame, bitmapFrame.Thumbnail, mData2, bitmapFrame.ColorContexts));
                        //originalImage.Delete();
                        using (Stream jpegStreamOut = System.IO.File.Open("d:\\2.jpg", FileMode.CreateNew, FileAccess.ReadWrite))
                        {
                            encoder.Save(jpegStreamOut);
                        }
                    }
                }
            }
        }
