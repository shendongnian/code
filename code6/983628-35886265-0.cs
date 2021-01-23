                //after pictureBox1's image has been set to the provided image.
                Bitmap image = new Bitmap(pictureBox1.Image);
                BlobCounter blobCounter = new BlobCounter();
                blobCounter.FilterBlobs = true;
                blobCounter.MinWidth = 50;
                blobCounter.MinHeight = 50;
                blobCounter.ProcessImage(image);
    
                Blob[] blobs = blobCounter.GetObjectsInformation();
    
                Blob blob = blobs[0];
    
                SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
    
                Graphics g = Graphics.FromImage(image);
                Pen redPen = new Pen(Color.Red, 2);
                Pen greenPen = new Pen(Color.Lime, 2);
                
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blob);
    
                List<IntPoint> corners;
    
                if (shapeChecker.IsConvexPolygon(edgePoints, out corners))
                {
                    PolygonSubType subType = shapeChecker.CheckPolygonSubType(corners);
    
                    Pen pen;
    
                    if (subType == PolygonSubType.Unknown)
                    {
                        pen = (corners.Count == 4) ? redPen : redPen;
                    }
                    else
                    {
                        pen = greenPen;
                    }
    
                    System.Drawing.Point[] array = new System.Drawing.Point[corners.Count];
    
                    for (int i = 0, n = corners.Count; i < n; i++)
                    {
                        array[i] = new System.Drawing.Point(corners[i].X + 1, corners[i].Y + 1);
                    }
    
                    g.DrawPolygon(pen, array);
                }
    
                redPen.Dispose();
                greenPen.Dispose();
                g.Dispose();
    
                pictureBox1.Image = image;
                pictureBox1.Width = image.Width;
                pictureBox1.Height = image.Height;
