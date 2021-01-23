        public static void TestResizeBitmapUpto(string file, string newFile)
        {
            try
            {
                using (var image = Bitmap.FromFile(file))
                {
                    if (image == null)
                        return;
                    using (Bitmap b = new Bitmap(image))
                    {
                        using (var newBitmap = ResizeBitmapUpto(b, 200, 200, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor))
                        {
                            newBitmap.Save(newFile);
                        }
                    }
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
                Debug.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
