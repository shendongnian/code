                e = SaveColorTimestamps.GetEnumerator();
                foreach (byte[] node in SaveColorFrames)
                {
                    e.MoveNext();
                    PngBitmapEncoder enc = new PngBitmapEncoder();
                    enc.Frames.Add(BitmapFrame.Create(BitmapSource.Create(640, 480, 96, 96, PixelFormats.Bgr32, null, node, 640*4)));
                    string temppath = System.IO.Path.Combine(@"../output/kinect1/color/", e.Current + ".png");
                    using (FileStream fs = new FileStream(temppath, FileMode.Create))
                    {
                        enc.Save(fs);
                        fs.Close();
                    }
                }
                SaveColorTimestamps.Clear();
                SaveColorFrames.Clear();
                e.Dispose();
                e = SaveDepthTimestamps.GetEnumerator();
                foreach (short[] node in SaveDepthFrames)
                {
                    e.MoveNext();
                    PngBitmapEncoder enc = new PngBitmapEncoder();
                    enc.Frames.Add(BitmapFrame.Create(BitmapSource.Create(640, 480, 96, 96, PixelFormats.Gray16, null, node, 640 * 2)));
                    string temppath = System.IO.Path.Combine(@"../output/kinect1/depth/", e.Current + ".png");
                    using (FileStream fs = new FileStream(temppath, FileMode.Create))
                    {
                        enc.Save(fs);
                        fs.Close();
                    }
                }
