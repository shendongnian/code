     if (File.Exists(filePathName))
                {
                    // read the file this way to open as read-only and cache the image in memory for use rather than keeping it open/locked and preventing updates to it
                    BitmapImage img = new BitmapImage();
                    using (FileStream fs = File.OpenRead(filePathName))
                    {
                        img.BeginInit();
                        img.CacheOption = BitmapCacheOption.OnLoad;
                        img.StreamSource = fs;
                        img.EndInit();
                        img.Freeze();
                    }
                    gridChartBg.Background = new ImageBrush(img);
                }
