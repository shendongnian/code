            //--------------------------------------PART 1 : DRAWING STUFF IN A BITMAP------------------------------------------------------------------------------------
            var blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
            var bmp = new Bitmap(1000, 1000, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                //This is just an example using three rectangles for illustration purposes. 
                //In reality I have a set of arbitrary lines defining complex polygons.
                g.DrawRectangle(blackPen, new Rectangle(10, 10, 200, 100)); //rectangle 1
                g.DrawRectangle(blackPen, new Rectangle(20, 20, 50, 30)); //rectangle 2
                g.DrawRectangle(blackPen, new Rectangle(200, 10, 25, 25)); //rectangle 3
            }
            var r = new Rectangle(10, 10, 250, 250); //bounding box of the 3 rectangles
            var rcrop = new Rectangle(r.X, r.Y, r.Width + 10, r.Height + 10);//This is the cropping rectangle (bonding box adding 10 extra units width and height)
            //Crop the model from the bmp
            var src = bmp;
            var target = new Bitmap(r.Width, r.Height);
            using (var gs = Graphics.FromImage(target))
            {
                gs.DrawImage(src, new Rectangle(5, 5, 250, 250), rcrop, GraphicsUnit.Pixel);
                gs.Dispose();
            }
            //--------------------------------------PART 3 : USING THE SAVED PICTURE AND FIND CONTOURS ----------------------------------------------------------------
            var imageFrame = new Image<Bgr, Byte>(target);
            //Find contours
            var grayFrame = imageFrame.Convert<Gray, byte>();
            var result = new List<Contour<Point>>();
            using (var storage = new MemStorage()) //allocate storage for contour approximation
                for (var contours = grayFrame.FindContours(CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, RETR_TYPE.CV_RETR_LIST, storage); contours != null; contours = contours.HNext)
                {
                    //here i do stuff with the contours and add them to the list result
                    result.Add(contours);
                }
