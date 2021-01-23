        // Using NuGet package OpenCvSharp-AnyCPU 2.4.10.20140320. 
        using (var imageStream = new MemoryStream())
        {
            using (var circleBoard = new System.Drawing.Bitmap(650, 850))
            using (var g = System.Drawing.Graphics.FromImage(circleBoard))
            {
                g.Clear(System.Drawing.Color.White);
                for (int y = 0; y <= 10; y += 1)
                    for (int x = 0; x <= 3; x += 1)
                    {
                        var dx = 10 + x * 150;
                        var dy = 10 + y * 75;
                        g.FillEllipse(System.Drawing.Brushes.Black, dx + ((y + 1) % 2) * 75, dy, 50, 50);
                    }
                circleBoard.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
            }
            Mat im = Cv2.ImDecode(imageStream.GetBuffer(), OpenCvSharp.LoadMode.GrayScale);
            Size patternsize = new Size(4, 11);
            var centers = new List<Point2f>();
            if (Cv2.FindCirclesGrid(im, patternsize, OutputArray<Point2f>.Create(centers), FindCirclesGridFlag.AsymmetricGrid | FindCirclesGridFlag.Clustering))
            {
                // Ok, finds 44 circles
                Console.WriteLine(centers.Count());
            }
            Point2f[] centers2 = null;
            if (Cv2.FindCirclesGrid(im, patternsize, out centers2, FindCirclesGridFlag.AsymmetricGrid | FindCirclesGridFlag.Clustering))
            {
                // Crashes with AccessViolationException
                Console.WriteLine(centers2.Count());
            }
        }
