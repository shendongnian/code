            int cropFromY = 240;
            int cropToY = 334;
            // Change location if required...
            using (FileStream fs = new FileStream(@"D:\Test\pic.png", FileMode.Open, FileAccess.Read))
            {
                // Step 1
                // load Bitmap from File
                var loadedBitmap = new Bitmap(fs);
                // Step 1 (extended)
                // As the loadedBitmap might have a wrong PixelFormat, we convert it to have an Alpha channel
                var source = new Bitmap(loadedBitmap.Width, loadedBitmap.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics gSource = Graphics.FromImage(source))
                {
                    gSource.DrawImageUnscaled(loadedBitmap, 0, 0);
                }
                // Step 2
                // Create destination Picture
                var destination = new Bitmap(source.Width, source.Height - (cropToY - cropFromY), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                // Step 3
                // Create the two graphics objects
                using (Graphics gSource = Graphics.FromImage(source))
                {
                    using (Graphics gDestination = Graphics.FromImage(destination))
                    {
                        // Step 4
                        // Copy picture source to destination => Crop Bottom
                        gDestination.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                        gDestination.DrawImageUnscaled(source, 0, 0);
                        // Step 5
                        // Make the top part (which is already drawn to the destination) transparent
                        gSource.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                        gSource.FillRectangle(Brushes.Transparent, new Rectangle(0, 0, source.Width, cropToY));
                        // Step 6
                        // Draw the source bitmap to the destination picture again, but this time you locate it at 0/-(y3-y1)
                        gDestination.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                        gDestination.DrawImageUnscaled(source, 0, -(cropToY - cropFromY));
                        // Step 7 
                        // Save new picture. Change location if required...
                        destination.Save(@"D:\Test\pic2.png");
                    }
                }
            }
