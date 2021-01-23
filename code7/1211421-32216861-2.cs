        public static void ResizeImage(Bitmap image, Bitmap destImage)
        {
            var destRect = new Rectangle(0, 0, destImage.Width, destImage.Height);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.Low;
                graphics.SmoothingMode = SmoothingMode.None;
                graphics.PixelOffsetMode = PixelOffsetMode.Default;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
        }
        private void CaptureScreen(Bitmap destImage)
        {
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CopyFromScreen(0, 0, 0, 0, new Size(destImage.Width, destImage.Height), CopyPixelOperation.SourceCopy);
            }
            
        }
        public void Start()
        {
            var size = new Size(1920, 1080);
            var fullSizeImgs = new Bitmap[2]
            {
                new Bitmap(size.Width, size.Height),
                new Bitmap(size.Width, size.Height)
            };
            var resizedImgs = new Bitmap[2]
            {
                new Bitmap((int)(size.Width / 10.0f), (int)(size.Height / 10.0f)),
                new Bitmap((int)(size.Width / 10.0f), (int)(size.Height / 10.0f))
            };
            var globalWatch = new Stopwatch();
            var codeWatch = new Stopwatch();
            int current = 0;
            int counter = 0;
            CaptureScreen(fullSizeImgs[current]);
            ResizeImage(fullSizeImgs[current], resizedImgs[current]);
            globalWatch.Start();
            while (true)
            {
                var next = (current + 1) % 2;
                long totalFrameTime = 0;
                {
                    codeWatch.Reset();
                    codeWatch.Start();
                    CaptureScreen(fullSizeImgs[next]);
                    codeWatch.Stop();
                    var elapsed = codeWatch.ElapsedMilliseconds;
                    Console.WriteLine("Capture : {0} ms", elapsed);
                    totalFrameTime += elapsed;
                }
                
                {
                    codeWatch.Reset();
                    codeWatch.Start();
                    ResizeImage(fullSizeImgs[next], resizedImgs[next]);
                    codeWatch.Stop();
                    var elapsed = codeWatch.ElapsedMilliseconds;
                    Console.WriteLine("Resize : {0} ms", elapsed);
                    totalFrameTime += elapsed;
                }
                {
                    codeWatch.Reset();
                    codeWatch.Start();
                    var rects = CodeImage(resizedImgs[current], resizedImgs[next]);
                    codeWatch.Stop();
                    var elapsed = codeWatch.ElapsedMilliseconds;
                    Console.WriteLine("Code : {0} ms", elapsed);
                    totalFrameTime += elapsed;
                }
                counter++;
                Console.WriteLine("Total : {0} ms\nFPS : {1}\n", totalFrameTime, counter / ((double)globalWatch.ElapsedMilliseconds / 1000.0));
                current = (current + 1) % 2;
            }
            globalWatch.Stop();
        }
